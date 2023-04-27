using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.Exceptions;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.Core.Domain.Employees;
using GMS.Core.WebHost.Attributes;
using GMS.Core.WebHost.Models;
using JWTAuthManager;
using Microsoft.Extensions.DependencyInjection;

namespace GMS.Core.BusinessLogic.Services
{
    [Inject(ServiceLifetime.Scoped)]
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITrainerRepository _trainerRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly IFitnessClubRepository _fitnessClubrepository;

        public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository, IFitnessClubRepository fitnessClubrepository,
            ITrainerRepository trainerRepository, IManagerRepository managerRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _fitnessClubrepository = fitnessClubrepository;
            _trainerRepository = trainerRepository;
            _managerRepository = managerRepository;
        }

        public async Task<PagedList<Guid>> GetPage(Guid userId, Guid fitnessClubId, int pageNumber, int pageSize)
        {
            var fitnessClub = await _fitnessClubrepository.GetAsync(fitnessClubId, true);

            if (fitnessClub == null)
                throw new NotExistException("FitnessClub", fitnessClubId);
            else if (fitnessClub.OwnerId != userId)
            {
                var IsEmployeeExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(fitnessClubId, userId);

                if (!IsEmployeeExist)
                    throw new AccessDeniedException("Employees");
            }

            var pagedList = await _employeeRepository.GetPagedAsync(fitnessClubId, pageNumber, pageSize);
            return pagedList;
        }

        public async Task<PagedList<Guid>> GetPagedTrainers(Guid fitnessClubId, int pageNumber, int pageSize)
        {
            var pagedList = await _trainerRepository.GetPageAsync(fitnessClubId, pageNumber, pageSize);
            return pagedList;
        }

        public async Task<PagedList<Guid>> GetPagedManagers(Guid userId, Guid fitnessClubId, int pageNumber, int pageSize)
        {
            var fitnessClub = await _fitnessClubrepository.GetAsync(fitnessClubId, true);

            if (fitnessClub == null)
                throw new NotExistException("FitnessClub", fitnessClubId);
            else if (fitnessClub.OwnerId != userId)
            {
                var IsEmployeeExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(fitnessClubId, userId);

                if(!IsEmployeeExist)
                    throw new AccessDeniedException("Employees");
            }

            var pagedList = await _managerRepository.GetPageAsync(fitnessClubId, pageNumber, pageSize);
            return pagedList;
        }

        public async Task<EmployeeDto> Get(Guid id, Guid userId)
        {
            var employee = await _employeeRepository.GetWithIncludeAsync(e => e.Id == id, e => e.FitnessClub);

            if (employee == null)
                throw new NotFoundException("Employee", id);
            else if (employee.FitnessClub.OwnerId != userId)
            {
                var IsEmployeeExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(employee.FitnessClubId, userId);

                if (!IsEmployeeExist)
                    throw new AccessDeniedException("Employee");
            }

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<Guid> Create(EmployeeCreateOrEditDto dto)
        {
            var fitnessClub = await _fitnessClubrepository.GetAsync(dto.FitnessClubId, true);

            if (fitnessClub == null)
                throw new NotExistException("FitnessClub", dto.FitnessClubId);
            else if (fitnessClub.OwnerId != dto.UserId)
            {
                var IsEmployeeExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(dto.FitnessClubId, dto.UserId);

                if (!IsEmployeeExist)
                    throw new AccessDeniedException("FitnessClub");
            }
            if (fitnessClub.IsDeleted)
                throw new EntityLockedException("FitnessClub", fitnessClub.Id);

            Employee employee;
            if (dto.Role == nameof(Priviliges.Coach))
                employee = _mapper.Map<Trainer>(dto);
            else if (dto.Role == nameof(Priviliges.Manager))
                employee = _mapper.Map<Manager>(dto);
            else if (dto.Role == nameof(Priviliges.Administrator))
                employee = _mapper.Map<Administrator>(dto);
            else
                employee = _mapper.Map<Employee>(dto);

            var result = await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveChangesAsync();

            return result.Id;
        }

        public async Task Update(EmployeeCreateOrEditDto dto)
        {
            var employee = await _employeeRepository.GetWithIncludeAsync(X => X.Id == dto.Id, x => x.FitnessClub);

            if (employee == null)
                throw new NotExistException("Employee", dto.Id);
            else if (employee.FitnessClub.OwnerId != dto.UserId)
            {
                var IsEmployeeExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(dto.FitnessClubId, dto.UserId);

                if (!IsEmployeeExist)
                    throw new AccessDeniedException("Employee");
            }
            if (employee.FitnessClub.IsDeleted)
                throw new EntityLockedException("FitnessClub", employee.FitnessClub.Id);
            else if (employee.IsDeleted)
                throw new EntityLockedException("Employee", dto.Id);

            _mapper.Map(dto, employee);

            await _employeeRepository.SaveChangesAsync();
        }

        public async Task AddToArchive(Guid id, Guid userId)
        {
            var employee = await _employeeRepository.GetWithIncludeAsync(X => X.Id == id, x => x.FitnessClub);

            if (employee == null)
                throw new NotExistException("Employee", id);
            else if (employee.FitnessClub.OwnerId != userId)
            {
                var IsEmployeeExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(employee.FitnessClubId, userId);

                if (!IsEmployeeExist)
                    throw new AccessDeniedException("Employee");
            }
            if (employee.FitnessClub.IsDeleted)
                throw new EntityLockedException("FitnessClub", employee.FitnessClub.Id);

            employee.IsDeleted = true;
            await _employeeRepository.SaveChangesAsync();
        }
    }
}
