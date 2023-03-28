using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Abstractions.Repositories;

namespace GMS.Core.BusinessLogic.Services
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly IMapper _mapper;
        private readonly ITimeSlotRepository _repository;

        public TimeSlotService(IMapper mapper, ITimeSlotRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task<List<TimeSlotDto>> GetAllPerDay(DateOnly date, Guid fitnessClubId, Guid trainerId)
        {
            throw new NotImplementedException();
        }
    }
}
