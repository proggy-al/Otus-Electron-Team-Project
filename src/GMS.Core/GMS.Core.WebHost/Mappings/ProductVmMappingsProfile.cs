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

            CreateMap<ProductCreateRequest, ProductCreateDto>()
                .ForMember(d => d.EmployeeId, map => map.Ignore());
        }
    }
}
