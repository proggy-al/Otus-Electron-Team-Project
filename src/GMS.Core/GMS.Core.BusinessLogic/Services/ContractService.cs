using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.Services.Base;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;

namespace GMS.Core.BusinessLogic.Services
{
    public class ContractService : BaseService<IContractRepository, Contract, ContractDto, Guid>, IContractService
    {
        public ContractService(IMapper mapper, IContractRepository repository) : base(mapper, repository) { }

        public async Task<List<ContractDto>> GetPage(int page, int itemsPerPage)
        {
            var entities = await _repository.GetPagedAsync(page, itemsPerPage);
            return _mapper.Map<List<Contract>, List<ContractDto>>(entities);
        }

        public async Task<List<ContractDto>> GetAllByManagerId(Guid managerId)
        {
            var entities = await _repository.GetAllByManagerIdAsync(managerId);
            return _mapper.Map<List<Contract>, List<ContractDto>>(entities);
        }

        public async Task<List<ContractDto>> GetAllByUserId(Guid userId)
        {
            var entities = await _repository.GetAllByUserIdAsync(userId);
            return _mapper.Map<List<Contract>, List<ContractDto>>(entities);
        }

        public async Task<List<ContractDto>> GetPageByManagerId(Guid managerId, int page, int itemsPerPage)
        {
            var entities = await _repository.GetPagedByManagerIdAsync(managerId, page, itemsPerPage);
            return _mapper.Map<List<Contract>, List<ContractDto>>(entities);
        }

        public async Task<List<ContractDto>> GetPageByUserId(Guid userId, int page, int itemsPerPage)
        {
            var entities = await _repository.GetPagedByUserIdAsync(userId, page, itemsPerPage);
            return _mapper.Map<List<Contract>, List<ContractDto>>(entities);
        }
    }
}
