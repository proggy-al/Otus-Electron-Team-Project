using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.Exceptions;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.WebHost.Models;

namespace GMS.Core.BusinessLogic.Services
{
    public class AreaService : IAreaService 
    {
        private readonly IMapper _mapper;
        private readonly IAreaRepository _areaRepository;
        private readonly IFitnessClubRepository _fitnessClubrepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AreaService(IMapper mapper, IAreaRepository repository, IFitnessClubRepository fitnessClubrepository, IEmployeeRepository employeerepository)
        {
            _mapper = mapper;
            _areaRepository = repository;
            _fitnessClubrepository = fitnessClubrepository;
            _employeeRepository = employeerepository;
        }

        public async Task<PagedList<AreaDto>> GetPage(Guid fitnessClubId, int pageNumber, int pageSize)
        {
            var pagedList = await _areaRepository.GetPagedAsync(fitnessClubId, pageNumber, pageSize, true);
            return new PagedList<AreaDto>
            {
                Entities = _mapper.Map<List<Area>, List<AreaDto>>(pagedList.Entities),
                Pagination = pagedList.Pagination
            };
        }

        public async Task<AreaDto> Get(Guid id)
        {
            var area = await _areaRepository.GetAsync(id, true);

            if (area == null)
                throw new NotFoundException("Area", id);

            return _mapper.Map<AreaDto>(area);
        }

        public async Task<Guid> Create(AreaCreateDto dto)
        {
            var fitnessClub = await _fitnessClubrepository.GetAsync(dto.FitnessClubId, true);

            if (fitnessClub == null)
                throw new NotExistException("FitnessClub", dto.FitnessClubId);
            else if (fitnessClub.OwnerId != dto.EmployeeId)
            {
                var IsEmployeeExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(dto.FitnessClubId, dto.EmployeeId);

                if (!IsEmployeeExist)
                    throw new AccessDeniedException("FitnessClub");
            }
            if (fitnessClub.IsDeleted)
                throw new EntityLockedException("FitnessClub", fitnessClub.Id);

            var area = _mapper.Map<Area>(dto);
            var result = await _areaRepository.AddAsync(area);
            await _areaRepository.SaveChangesAsync();

            return result.Id;
        }

        public async Task Update(Guid id, AreaEditDto dto)
        {
            var area = await _areaRepository.GetWithIncludeAsync(X => X.Id == id, x => x.FitnessClub);

            if (area == null)
                throw new NotExistException("Area", id);
            else if (area.FitnessClub.OwnerId != dto.EmployeeId)
            {
                var IsEmployeeExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(area.FitnessClub.Id, dto.EmployeeId);

                if (!IsEmployeeExist)
                    throw new AccessDeniedException("Area");
            }
            if (area.FitnessClub.IsDeleted)
                throw new EntityLockedException("FitnessClub", area.FitnessClub.Id);
            else if (area.IsDeleted)
                throw new EntityLockedException("Area", id);

            _mapper.Map(dto,area);
            await _areaRepository.SaveChangesAsync();
        }

        public async Task AddToArchive(Guid id, Guid employeeId)
        {
            var area = await _areaRepository.GetWithIncludeAsync(X => X.Id == id, x => x.FitnessClub);

            if (area == null)
                throw new NotExistException("Area", id);
            else if (area.FitnessClub.OwnerId != employeeId)
            {
                var IsEmployeeExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(area.FitnessClub.Id, employeeId);

                if (!IsEmployeeExist)
                    throw new AccessDeniedException("Area");
            }
            if (area.FitnessClub.IsDeleted)
                throw new EntityLockedException("FitnessClub", area.FitnessClub.Id);

            area.IsDeleted = true;
            await _areaRepository.SaveChangesAsync();
        }
    }
}
