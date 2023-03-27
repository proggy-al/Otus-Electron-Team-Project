using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Domain;

namespace GMS.Core.BusinessLogic.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности продукта
    /// </summary>
    public class ProductMappingsProfile : Profile
    {
        public ProductMappingsProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>()
                .ForMember(d => d.FitnessClub, map => map.Ignore())
                .ForMember(d => d.Contracts, map => map.Ignore());

            CreateMap<Product, ProductCreateDto>()
                .ForMember(d => d.OwnerId, map => map.Ignore());
            CreateMap<ProductCreateDto, Product>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.IsDeleted, map => map.Ignore())
                .ForMember(d => d.FitnessClub, map => map.Ignore())
                .ForMember(d => d.Contracts, map => map.Ignore());
        }
    }
}
