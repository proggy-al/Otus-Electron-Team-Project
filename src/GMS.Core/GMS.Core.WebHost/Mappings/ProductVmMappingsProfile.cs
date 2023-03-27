using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Models;

namespace GMS.Core.WebHost.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности продукта
    /// </summary>
    public class ProductVmMappingsProfile : Profile
    {
        public ProductVmMappingsProfile()
        {
            CreateMap<ProductDto, ProductResponse>();
            CreateMap<ProductResponse, ProductDto>()
                .ForMember(d => d.FitnessClubId, map => map.Ignore())
                .ForMember(d => d.IsDeleted, map => map.Ignore());

            CreateMap<ProductCreateDto, ProductCreateRequest>();
            CreateMap<ProductCreateRequest, ProductCreateDto>()
                .ForMember(d => d.OwnerId, map => map.Ignore());
        }
    }
}
