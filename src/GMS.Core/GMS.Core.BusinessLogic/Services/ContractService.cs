using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;

namespace GMS.Core.BusinessLogic.Services
{
    public class ContractService : IContractService
    {
        private readonly IMapper _mapper;
        private readonly IContractRepository _repository;

        public ContractService(IMapper mapper, IContractRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ContractDto>> GetPage(int pageNumber, int pageSize)
        {
            var entities = await _repository.GetPagedAsync(pageNumber, pageSize);
            return _mapper.Map<List<Contract>, List<ContractDto>>(entities);
          //  throw new NotImplementedException();
        }

        public async Task<List<ContractDto>> GetPageByFitnessClubId(Guid fitnessClubId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ContractDto>> GetPageByManagerId(Guid managerId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ContractDto>> GetPageByUserId(Guid userId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
