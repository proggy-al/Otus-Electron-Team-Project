using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.Services.Base;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;

namespace GMS.Core.BusinessLogic.Services
{
    public class AreaService : BaseService<IAreaRepository, Area, AreaDto, Guid>, IAreaService
    {
        public AreaService(IMapper mapper, IAreaRepository repository) : base(mapper, repository) { }

        public async Task<List<AreaDto>> GetPage(int page, int itemsPerPage)
        {
            var entities = await _repository.GetPagedAsync(page, itemsPerPage);
            return _mapper.Map<List<Area>, List<AreaDto>>(entities);
        }

        public async Task<List<AreaDto>> GetAllByFitnessClubId(Guid fitnessClubId)
        {
            var entities = await _repository.GetAllByFitnessClubIdAsync(fitnessClubId);
            return _mapper.Map<List<Area>, List<AreaDto>>(entities);
        }

        public async Task<List<AreaDto>> GetPageByFitnessClubId(Guid fitnessClubId, int page, int itemsPerPage)
        {
            var entities = await _repository.GetPagedByFitnessClubIdAsync(fitnessClubId,page,itemsPerPage);
            return _mapper.Map<List<Area>, List<AreaDto>>(entities);
        }
    }
}
