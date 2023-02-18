using AutoMapper;
using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.Services.Base;
using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;

namespace GMS.Core.BusinessLogic.Services
{
    public class ProductService : BaseService<IProductRepository, Product, ProductDto, Guid>, IProductService
    {
        public ProductService(IMapper mapper, IProductRepository repository) : base(mapper, repository) { }

        public async Task<List<ProductDto>> GetPage(int page, int itemsPerPage)
        {
            var entities = await _repository.GetPagedAsync(page, itemsPerPage);
            return _mapper.Map<List<Product>, List<ProductDto>>(entities);
        }

        public async Task<List<ProductDto>> GetAllByFitnessClubId(Guid fitnessClubId)
        {
            var entities = await _repository.GetAllByFitnessClubIdAsync(fitnessClubId);
            return _mapper.Map<List<Product>, List<ProductDto>>(entities);
        }

        public async Task<List<ProductDto>> GetPageByFitnessClubId(Guid fitnessClubId, int page, int itemsPerPage)
        {
            var entities = await _repository.GetPagedByFitnessClubIdAsync(fitnessClubId, page, itemsPerPage);
            return _mapper.Map<List<Product>, List<ProductDto>>(entities);
        }
    }
}
