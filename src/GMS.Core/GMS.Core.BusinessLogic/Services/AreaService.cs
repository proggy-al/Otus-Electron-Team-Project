using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Abstractions.Repositories;

namespace GMS.Core.BusinessLogic.Services
{
    public class AreaService : IAreaService 
    {
        private readonly IMapper _mapper;
        private readonly IAreaRepository _repository;

        public AreaService(IMapper mapper, IAreaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task<List<AreaDto>> GetPage(Guid fitnessClubId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
