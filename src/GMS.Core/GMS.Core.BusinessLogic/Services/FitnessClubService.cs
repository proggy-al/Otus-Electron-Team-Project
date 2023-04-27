using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.Exceptions;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.WebHost.Attributes;
using GMS.Core.WebHost.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GMS.Core.BusinessLogic.Services
{
    [Inject(ServiceLifetime.Scoped)]
    public class FitnessClubService : IFitnessClubService
    {
        private readonly IMapper _mapper;
        private readonly IFitnessClubRepository _repository;
        private readonly IEmployeeRepository _employeeRepository;

        public FitnessClubService(IMapper mapper, IFitnessClubRepository repository, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _employeeRepository = employeeRepository;
        }

        public async Task<PagedList<FitnessClubDto>> GetPage(int pageNumber, int pageSize)
        {
            var pagedList = await _repository.GetPagedAsync(pageNumber, pageSize, true);
            return new PagedList<FitnessClubDto>
            {
                Entities = _mapper.Map<List<FitnessClub>, List<FitnessClubDto>>(pagedList.Entities),
                Pagination = pagedList.Pagination
            };
        }

        public async Task<PagedList<FitnessClubDto>> GetPageByOwnerId(Guid UserId, int pageNumber, int pageSize)
        {
            var pagedList = await _repository.GetPageByOwnerIdAsync(UserId, pageNumber, pageSize, true);
            return new PagedList<FitnessClubDto>
            {
                Entities = _mapper.Map<List<FitnessClub>, List<FitnessClubDto>>(pagedList.Entities),
                Pagination = pagedList.Pagination
            };
        }

        public async Task<FitnessClubDto> Get(Guid id)
        {
            var fitnessClub = await _repository.GetAsync(id, true);

            if (fitnessClub == null)
                throw new NotFoundException("FitnessClub", id);

            return _mapper.Map<FitnessClubDto>(fitnessClub);
        }

        public async Task<Guid> Create(FitnessClubCreateDto dto)
        {
            var fitnessClub = _mapper.Map<FitnessClub>(dto);

            var result = await _repository.AddAsync(fitnessClub);
            await _repository.SaveChangesAsync();

            return result.Id;
        }

        public async Task Update(Guid id, FitnessClubEditDto dto)
        {
            var fitnessClub = await _repository.GetAsync(id);

            if (fitnessClub == null)
                throw new NotExistException("FitnessClub", id);
            else if (fitnessClub.OwnerId != dto.UserId)
            {
                var IsEmployeeExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(fitnessClub.Id, dto.UserId);

                if(!IsEmployeeExist)
                    throw new AccessDeniedException("FitnessClub");
            }
            if (fitnessClub.IsDeleted)
                throw new EntityLockedException("FitnessClub", id);

            _mapper.Map(dto, fitnessClub);
            await _repository.SaveChangesAsync();
        }

        public async Task AddToArchive(Guid id, Guid userId)
        {
            var fitnessClub = await _repository.GetAsync(id);

            if (fitnessClub == null)
                throw new NotExistException("FitnessClub", id);
            else if (fitnessClub.OwnerId != userId)
                throw new AccessDeniedException("FitnessClub");

            fitnessClub.IsDeleted = true;
            await _repository.SaveChangesAsync();
        }
    }
}
