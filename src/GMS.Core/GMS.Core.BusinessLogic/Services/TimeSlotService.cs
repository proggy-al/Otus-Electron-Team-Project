using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.Services.Base;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;

namespace GMS.Core.BusinessLogic.Services
{
    public class TimeSlotService : BaseService<ITimeSlotRepository, TimeSlot, TimeSlotDto, Guid>, ITimeSlotService
    {
        public TimeSlotService(IMapper mapper, ITimeSlotRepository repository) : base(mapper, repository) { }

        public async Task<List<TimeSlotDto>> GetAllPerDay(DateOnly date, Guid fitnessClubId, Guid trainerId)
        {
            var entities = await _repository.GetAllPerDayAsync(date, fitnessClubId, trainerId);
            return _mapper.Map<List<TimeSlot>, List<TimeSlotDto>>(entities);
        }
    }
}
