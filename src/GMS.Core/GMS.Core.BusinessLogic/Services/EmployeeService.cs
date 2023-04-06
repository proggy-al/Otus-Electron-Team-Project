using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.Exceptions;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.WebHost.Models;

namespace GMS.Core.BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IFitnessClubRepository _fitnessClubrepository;

        public EmployeeService(IMapper mapper, IEmployeeRepository repository, IFitnessClubRepository fitnessClubrepository)
        {
            _mapper = mapper;
            _employeeRepository = repository;
            _fitnessClubrepository = fitnessClubrepository;
        }

        public async Task<PagedList<Guid>> GetPage(Guid ownerId, Guid fitnessClubId, int pageNumber, int pageSize)
        {
            var fitnessClub = await _fitnessClubrepository.GetAsync(fitnessClubId, true);

            if (fitnessClub == null)
                throw new NotExistException("FitnessClub", fitnessClubId);
            else if (fitnessClub.OwnerId != ownerId)
                throw new AccessDeniedException("Employees");

            var pagedList = await _employeeRepository.GetPagedAsync(fitnessClubId, pageNumber, pageSize);
            return pagedList;
        }

        public async Task<EmployeeDto> Get(Guid id, Guid ownerId)
        {
            var employee = await _employeeRepository.GetWithIncludeAsync(e => e.Id == id, e => e.FitnessClub);

            if (employee == null)
                throw new NotFoundException("Employee", id);
            else if (employee.FitnessClub.OwnerId != ownerId)
                throw new AccessDeniedException("Employee");

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<Guid> Create(EmployeeCreateOrEditDto dto)
        {
            var fitnessClub = await _fitnessClubrepository.GetAsync(dto.FitnessClubId, true);

            if (fitnessClub == null)
                throw new NotExistException("FitnessClub", dto.FitnessClubId);
            else if (fitnessClub.OwnerId != dto.OwnerId)
                throw new AccessDeniedException("FitnessClub");
            else if (fitnessClub.IsDeleted)
                throw new EntityLockedException("FitnessClub", fitnessClub.Id);

            var employee = _mapper.Map<Employee>(dto);

            var result = await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveChangesAsync();

            return result.Id;
        }

        public async Task Update(EmployeeCreateOrEditDto dto)
        {
            var employee = await _employeeRepository.GetWithIncludeAsync(X => X.Id == dto.Id, x => x.FitnessClub);

            if (employee == null)
                throw new NotExistException("Employee", dto.Id);
            else if (employee.FitnessClub.OwnerId != dto.OwnerId)
                throw new AccessDeniedException("Employee");
            else if (employee.FitnessClub.IsDeleted)
                throw new EntityLockedException("FitnessClub", employee.FitnessClub.Id);
            else if (employee.IsDeleted)
                throw new EntityLockedException("Employee", dto.Id);

            _mapper.Map(dto, employee);

            await _employeeRepository.SaveChangesAsync();
        }

        public async Task AddToArchive(Guid id, Guid ownerId)
        {
            var employee = await _employeeRepository.GetWithIncludeAsync(X => X.Id == id, x => x.FitnessClub);

            if (employee == null)
                throw new NotExistException("Employee", id);
            else if (employee.FitnessClub.OwnerId != ownerId)
                throw new AccessDeniedException("Employee");
            else if (employee.FitnessClub.IsDeleted)
                throw new EntityLockedException("FitnessClub", employee.FitnessClub.Id);

            employee.IsDeleted = true;
            await _employeeRepository.SaveChangesAsync();
        }
    }
}
