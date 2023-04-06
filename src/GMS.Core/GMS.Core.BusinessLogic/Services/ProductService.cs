using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.Exceptions;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.WebHost.Models;

namespace GMS.Core.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IFitnessClubRepository _fitnessClubrepository;
        private readonly IEmployeeRepository _employeeRepository;
        public ProductService(IMapper mapper, IProductRepository repository, IFitnessClubRepository fitnessClubrepository, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _productRepository = repository;
            _fitnessClubrepository = fitnessClubrepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<PagedList<ProductDto>> GetPage(Guid fitnessClubId, int pageNumber, int pageSize)
        {
            var pagedList = await _productRepository.GetPagedAsync(fitnessClubId, pageNumber, pageSize, true);
            return new PagedList<ProductDto>
            {
                Entities = _mapper.Map<List<Product>, List<ProductDto>>(pagedList.Entities),
                Pagination = pagedList.Pagination
            };
        }

        public async Task<ProductDto> Get(Guid id)
        {
            var product = await _productRepository.GetAsync(id, true);
            
            if(product == null)
                throw new NotFoundException("Product", id);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<Guid> Create(ProductCreateDto dto)
        {
            var fitnessClub = await _fitnessClubrepository.GetAsync(dto.FitnessClubId, true);

            if (fitnessClub == null)
                throw new NotExistException("FitnessClub", dto.FitnessClubId);

            var IsEmployeeExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(dto.FitnessClubId, dto.EmployeeId);

            if (fitnessClub.OwnerId != dto.EmployeeId && !IsEmployeeExist)
                throw new AccessDeniedException("FitnessClub");
            else if (fitnessClub.IsDeleted)
                throw new EntityLockedException("FitnessClub", fitnessClub.Id);

            var product = _mapper.Map<Product>(dto);

            var result = await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();

            return result.Id;
        }

        public async Task AddToArchive(Guid id, Guid employeeId)
        {
            var product = await _productRepository.GetWithIncludeAsync(X=>X.Id == id, x => x.FitnessClub);
            
            if (product == null)
                throw new NotExistException("Product", id);

            var IsEmployeeExist = await _employeeRepository.IsEmployeeWorkingInFitnessClub(product.FitnessClubId, employeeId);

            if (product.FitnessClub.OwnerId != employeeId && !IsEmployeeExist)
                throw new AccessDeniedException("Product");
            else if (product.FitnessClub.IsDeleted)
                throw new EntityLockedException("FitnessClub", product.FitnessClub.Id);

            product.IsDeleted = true;
            await _productRepository.SaveChangesAsync();
        }
    }
}