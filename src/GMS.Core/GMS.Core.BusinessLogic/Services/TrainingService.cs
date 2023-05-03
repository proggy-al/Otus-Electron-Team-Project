using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.Exceptions;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.WebHost.Attributes;
using GMS.Core.WebHost.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GMS.Core.BusinessLogic.Services
{
    [Inject(ServiceLifetime.Scoped)]
    public class TrainingService : ITrainingService
    {
        private readonly IMapper _mapper;
        private readonly ITrainingRepository _trainingRepository;
        private readonly ITimeSlotRepository _timeSlotRepository;

        public TrainingService(IMapper mapper, ITrainingRepository repository, ITimeSlotRepository timeSlotRepository)
        {
            _mapper = mapper;
            _trainingRepository = repository;
            _timeSlotRepository = timeSlotRepository;
        }

        public async Task<PagedList<TrainingUserDto>> GetPageByUserId(Guid userId, int pageNumber, int pageSize)
        {
            var pagedList = await _trainingRepository.GetPagedByUserIdAsync(userId, pageNumber, pageSize);
            return new PagedList<TrainingUserDto>
            {
                Entities = _mapper.Map<List<Training>, List<TrainingUserDto>>(pagedList.Entities),
                Pagination = pagedList.Pagination
            };
        }

        public async Task<PagedList<TrainingTrainerDto>> GetPagedPastByTrainerId(Guid trainerId, int pageNumber, int pageSize)
        {
            var pagedList = await _trainingRepository.GetPagedPastByTrainerIdAsync(trainerId, pageNumber, pageSize);
            return new PagedList<TrainingTrainerDto>
            {
                Entities = _mapper.Map<List<Training>, List<TrainingTrainerDto>>(pagedList.Entities),
                Pagination = pagedList.Pagination
            };
        }

        public async Task<PagedList<TrainingTrainerDto>> GetPagedByTrainerId(Guid trainerId, int pageNumber, int pageSize)
        {
            var pagedList = await _trainingRepository.GetPagedByTrainerIdAsync(trainerId, pageNumber, pageSize);
            return new PagedList<TrainingTrainerDto>
            {
                Entities = _mapper.Map<List<Training>, List<TrainingTrainerDto>>(pagedList.Entities),
                Pagination = pagedList.Pagination
            };
        }

        public async Task<TrainingUserDto> AddTraining(TrainingCreateDto dto)
        {
            //var timeslot = await _timeSlotRepository.GetAsync(dto.TimeSlotId);
            var timeslot = await _timeSlotRepository.GetWithIncludeAsync(t => t.Id == dto.TimeSlotId, t => t.Area, t => t.Area.FitnessClub);

            if (timeslot == null) 
                throw new NotExistException("TimeSlot", dto.TimeSlotId);
            else if (timeslot.IsDeleted)
                throw new EntityLockedException("TimeSlot", timeslot.Id);
            else if (timeslot.DateTime <= DateTime.Now.ToUniversalTime())
                throw new BadRequestException("You cannot add a training in the past.");
            else if (timeslot.IsBusy)
                throw new TimeslotIsBusyException(timeslot.Name, timeslot.DateTime);

            var training = _mapper.Map<Training>(dto);

            // Todo: применить транзакцию?
            var result = await _trainingRepository.AddAsync(training);
            await _trainingRepository.SaveChangesAsync();

            timeslot.IsBusy = true;
            await _timeSlotRepository.SaveChangesAsync();

            training.TimeSlot = timeslot;
            var trainingDto = _mapper.Map<Training, TrainingUserDto>(training);
            return trainingDto;
        }

        public async Task AddTrainerNotes(Guid id, TrainingTrainerNotesDto dto)
        {
            var training = await _trainingRepository.GetWithIncludeAsync(t => t.Id == id, t => t.TimeSlot);

            if (training == null)
                throw new NotExistException("Training", id);
            else if (training.IsDeleted)
                throw new EntityLockedException("Training", id);
            else if (training.TimeSlot.TrainerId != dto.TrainerId)
                throw new AccessDeniedException("Training");
            else if (training.TimeSlot.DateTime >= DateTime.Now.ToUniversalTime())
                throw new BadRequestException("You cannot add a trainers note because training has not started.");
            else if (!training.TimeSlot.IsBusy)
                throw new BadRequestException("You cannot add a trainers note because no one signed up for training.");

            _mapper.Map(dto, training);
            await _trainingRepository.SaveChangesAsync();
        }

        public async Task Cancel(Guid id, Guid userId, int hoursNoLaterThan = 24)
        {
            var training = await _trainingRepository.GetWithIncludeAsync(t => t.Id == id, t => t.TimeSlot);

            if (training == null)
                throw new NotExistException("Training", id);
            else if (training.UserId != userId)
                throw new AccessDeniedException("Training");
            else if (training.TimeSlot.DateTime < DateTime.Now.AddHours(hoursNoLaterThan))
                throw new UnableToСancelTrainingException(hoursNoLaterThan);

            // Todo: применить транзакцию?
            _trainingRepository.Delete(id);
            await _trainingRepository.SaveChangesAsync();

            training.TimeSlot.IsBusy = false;
            await _timeSlotRepository.SaveChangesAsync();
        }
    }
}
