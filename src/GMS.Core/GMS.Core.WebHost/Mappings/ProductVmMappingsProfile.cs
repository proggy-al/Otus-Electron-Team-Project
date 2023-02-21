using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.VIewModels;

namespace GMS.Core.WebHost.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности продукта
    /// </summary>
    public class ProductVmMappingsProfile : Profile
    {
        public ProductVmMappingsProfile()
        {
            CreateMap<ProductVM, ProductDto>();
            CreateMap<ProductDto, ProductVM>();
        }
    }
}
