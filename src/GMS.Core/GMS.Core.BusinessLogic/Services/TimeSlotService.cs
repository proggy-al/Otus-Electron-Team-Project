using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.Exceptions;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.WebHost.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace GMS.Core.BusinessLogic.Services
{
    [Inject(ServiceLifetime.Scoped)]
    public class TimeSlotService : ITimeSlotService
    {
        private readonly IMapper _mapper;
        private readonly ITimeSlotRepository _timeSlotRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAreaRepository _areaRepository;
        private readonly ITrainingRepository _trainingRepository;

        public TimeSlotService(IMapper mapper, ITimeSlotRepository repository, IEmployeeRepository employeeRepository, IAreaRepository areaRepository, ITrainingRepository trainingRepository)
        {
            _mapper = mapper;
            _timeSlotRepository = repository;
            _employeeRepository = employeeRepository;
            _areaRepository = areaRepository;
            _trainingRepository = trainingRepository;
        }

        public async Task<List<TimeSlotDto>> GetAllPerDay(DateOnly date, Guid trainerId)
        {
            var timeSlots = await _timeSlotRepository.GetAllPerDayAsync(date, trainerId);
            return _mapper.Map<List<TimeSlot>, List<TimeSlotDto>>(timeSlots);
        }

        public async Task<TimeSlotDto> Get(Guid id)
        {
            var timeSlot = await _timeSlotRepository.GetWithIncludeAsync(t => t.Id == id,t => t.Area);
            return _mapper.Map<TimeSlotDto>(timeSlot);
        }

        public async Task<Guid> Create(TimeSlotCreateDto dto)
        {
            dto.DateTime = dto.DateTime.ToUniversalTime();

            if (dto.DateTime <= DateTime.Now.ToUniversalTime())
                throw new BadRequestException("You cannot add a time slot in the past.");

            var area = await _areaRepository.GetWithIncludeAsync(a => a.Id == dto.AreaId, a => a.FitnessClub);

            if (area == null)
                throw new NotExistException("Area", dto.AreaId);
            // проверка доступа сотрудника к созданию TimeSlot
            else if (area.FitnessClub.OwnerId != dto.UserId)
            {
                var IsEmployeeExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(area.FitnessClub.Id, dto.UserId);

                if(!IsEmployeeExist)
                    throw new AccessDeniedException("FitnessClub");
            }
            if (area.IsDeleted)
                throw new EntityLockedException("Area", area.Id);
            else if (area.FitnessClub.IsDeleted)
                throw new EntityLockedException("FitnessClub", area.FitnessClub.Id);

            // проверка работает ли тренер в фитнес клубе
            var IsTrainerExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(area.FitnessClub.Id, dto.TrainerId);
            if(!IsTrainerExist)
                throw new NotExistException("Trainer", dto.TrainerId);

            // проверка свободного времени у тренера
            var timeSlotBefore = await _timeSlotRepository.GetFirstBeforeDateTime(dto.TrainerId,dto.DateTime);
            if (timeSlotBefore != null && 
                timeSlotBefore.DateTime.AddMinutes(timeSlotBefore.Duration) > dto.DateTime)
                throw new TimeIntervalIsNotFreeException(timeSlotBefore.DateTime, timeSlotBefore.Duration);

            var timeSlotAfterOrIn = await _timeSlotRepository.GetFirstAfterOrInDateTime(dto.TrainerId, dto.DateTime);
            if (timeSlotAfterOrIn != null && 
                timeSlotAfterOrIn.DateTime < dto.DateTime.AddMinutes(dto.Duration))
                throw new TimeIntervalIsNotFreeException(timeSlotAfterOrIn.DateTime, timeSlotAfterOrIn.Duration);

            // добавление TimeSlot
            var timeSlot = _mapper.Map<TimeSlot>(dto);
            var result = await _timeSlotRepository.AddAsync(timeSlot);
            await _timeSlotRepository.SaveChangesAsync();

            return result.Id;
        }

        public async Task AddToArchive(Guid id, Guid userId)
        {
            var timeSlot = await _timeSlotRepository.GetWithIncludeAsync(t => t.Id == id, t => t.Area.FitnessClub, t => t.Training);

            if (timeSlot == null)
                throw new NotExistException("TimeSlot", id);
            // проверка доступа сотрудника к удалению TimeSlot
            else if (timeSlot.Area.FitnessClub.OwnerId != userId)
            {
                var IsEmployeeExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(timeSlot.Area.FitnessClub.Id, userId);

                if (!IsEmployeeExist)
                    throw new AccessDeniedException($"FitnessClub {timeSlot.Area.FitnessClub.Name}");
            }
            if (timeSlot.DateTime < DateTime.Now.ToUniversalTime())
                throw new BadRequestException("You cannot add to an archive the TimeSlot because has already finished.");

            // ToDo: сделать транзакцию?
            timeSlot.IsDeleted = true;
            await _timeSlotRepository.SaveChangesAsync();

            _trainingRepository.Delete(timeSlot.Training.Id);
            await _trainingRepository.SaveChangesAsync();
        }
    }
}
