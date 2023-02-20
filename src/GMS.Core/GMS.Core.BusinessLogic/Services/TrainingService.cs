using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.Services.Base;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;

namespace GMS.Core.BusinessLogic.Services
{
    public class TrainingService : BaseService<ITrainingRepository, Training, TrainingDto, Guid>, ITrainingService
    {
        public TrainingService(IMapper mapper, ITrainingRepository repository) : base(mapper, repository) { }

        public async Task<List<TrainingDto>> GetPage(int page, int itemsPerPage)
        {
            var entities = await _repository.GetPagedAsync(page, itemsPerPage);
            return _mapper.Map<List<Training>, List<TrainingDto>>(entities);
        }

        public async Task<List<TrainingDto>> GetAllByUserId(Guid userId)
        {
            var entities = await _repository.GetAllByUserIdAsync(userId);
            return _mapper.Map<List<Training>, List<TrainingDto>>(entities);
        }

        public async Task<List<TrainingDto>> GetPageByUserId(Guid userId, int page, int itemsPerPage)
        {
            var entities = await _repository.GetPagedByUserIdAsync(userId, page, itemsPerPage);
            return _mapper.Map<List<Training>, List<TrainingDto>>(entities);
        }
    }
}
