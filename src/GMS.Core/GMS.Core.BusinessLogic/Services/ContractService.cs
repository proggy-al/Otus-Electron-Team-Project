using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.Exceptions;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.WebHost.Models;

namespace GMS.Core.BusinessLogic.Services
{
    public class ContractService : IContractService
    {
        private readonly IMapper _mapper;
        private readonly IContractRepository _contractRepository;
        private readonly IFitnessClubRepository _fitnessClubrepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ContractService(IMapper mapper, IContractRepository contractRepository,
            IFitnessClubRepository fitnessClubRepository, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
            _fitnessClubrepository = fitnessClubRepository;
            _employeeRepository = employeeRepository;
        }

        private async Task<PagedList<ContractDto>> GetPage(Guid employeeId, Guid fitnessClubId, int pageNumber, int pageSize, bool IsApproved)
        {
            var fitnessClub = await _fitnessClubrepository.GetAsync(fitnessClubId, true);
            if (fitnessClub == null)
                throw new NotExistException("FitnessClub", fitnessClubId);

            var IsEmployeeExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(fitnessClubId, employeeId);
            if (fitnessClub.OwnerId != employeeId && !IsEmployeeExist)
                throw new AccessDeniedException("Contract");

            var pagedList = await _contractRepository.GetPageAsync(fitnessClubId, pageNumber, pageSize, IsApproved);
            return new PagedList<ContractDto>
            {
                Entities = _mapper.Map<List<Contract>, List<ContractDto>>(pagedList.Entities),
                Pagination = pagedList.Pagination
            };
        }
        public async Task<PagedList<ContractDto>> GetPageNotApproved(Guid employeeId, Guid fitnessClubId, int pageNumber, int pageSize)
        {
            return await GetPage(employeeId,fitnessClubId,pageNumber,pageSize,false);
        }

        public async Task<PagedList<ContractDto>> GetPageApproved(Guid employeeId, Guid fitnessClubId, int pageNumber, int pageSize)
        {
            return await GetPage(employeeId, fitnessClubId, pageNumber, pageSize, true);
        }

        public async Task<PagedList<ContractWithFсDto>> GetPageByUserId(Guid userId, int pageNumber, int pageSize)
        {
            var pagedList = await _contractRepository.GetPageByUserId(userId, pageNumber, pageSize);
            return new PagedList<ContractWithFсDto>
            {
                Entities = _mapper.Map<List<Contract>, List<ContractWithFсDto>>(pagedList.Entities),
                Pagination = pagedList.Pagination
            };
        }

        public async Task<Guid> Create(Guid productId, Guid userId)
        {
            var contract = new Contract
            {
                ProductId = productId,
                ManagerId = Guid.Empty,
                UserId = userId,
                IsApproved = false,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(365)
            };

            var result = await _contractRepository.AddAsync(contract);
            await _contractRepository.SaveChangesAsync();

            return result.Id;
        }

        public async Task Approve(Guid contractId, Guid emploeeId)
        {
            var contract = await _contractRepository.GetWithIncludeAsync(c => c.Id == contractId, c => c.Product.FitnessClub);

            if (contract == null)
                throw new NotExistException("Contract", contractId);
            else if(contract.IsApproved == true)
                throw new ContractAlreadyApprovedException(contractId);

            var IsEmployeeExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(contract.Product.FitnessClubId, emploeeId);

            if (contract.Product.FitnessClub.OwnerId != emploeeId && !IsEmployeeExist)
                throw new AccessDeniedException("Contract");
            else if (contract.Product.FitnessClub.IsDeleted)
                throw new EntityLockedException("FitnessClub", contract.Product.FitnessClub.Id);

            contract.IsApproved = true;
            contract.ManagerId = emploeeId;

            await _contractRepository.SaveChangesAsync();
        }
    }
}
