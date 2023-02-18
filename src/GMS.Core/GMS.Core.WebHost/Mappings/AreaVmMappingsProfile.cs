using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.VIewModels;

namespace GMS.Core.WebHost.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности зоны
    /// </summary>
    public class AreaVmMappingsProfile : Profile
    {
        public AreaVmMappingsProfile()
        {
            CreateMap<AreaVM, AreaDto>();
            CreateMap<AreaDto, AreaVM>();
        }
    }
}
