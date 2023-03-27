using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Models;

namespace GMS.Core.WebHost.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности зоны
    /// </summary>
    public class AreaVmMappingsProfile : Profile
    {
        public AreaVmMappingsProfile()
        {
            CreateMap<AreaDto, AreaResponse>();
            CreateMap<AreaResponse, AreaDto>()
                .ForMember(d => d.IsDeleted, map => map.Ignore());
        }
    }
}
