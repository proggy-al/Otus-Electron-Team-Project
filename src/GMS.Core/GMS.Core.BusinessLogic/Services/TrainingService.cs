using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Abstractions.Repositories;

namespace GMS.Core.BusinessLogic.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly IMapper _mapper;
        private readonly ITrainingRepository _repository;

        public TrainingService(IMapper mapper, ITrainingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task<List<TrainingDto>> EditTrainerNotes(Guid userId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<TrainingDto>> GetAllByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TrainingDto>> GetPage(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<TrainingDto>> GetPageByUserId(Guid userId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
