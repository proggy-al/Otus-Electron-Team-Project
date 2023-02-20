using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.Services.Base;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;

namespace GMS.Core.BusinessLogic.Services
{
    public class FitnessClubService : BaseService<IFitnessClubRepository, FitnessClub, FitnessClubDto, Guid>, IFitnessClubService
    {
        public FitnessClubService(IMapper mapper, IFitnessClubRepository repository) : base(mapper, repository) { }

        public async Task<List<FitnessClubDto>> GetPage(int page, int itemsPerPage)
        {
            var entities = await _repository.GetPagedAsync(page, itemsPerPage);
            return _mapper.Map<List<FitnessClub>, List<FitnessClubDto>>(entities);
        }
    }
}
