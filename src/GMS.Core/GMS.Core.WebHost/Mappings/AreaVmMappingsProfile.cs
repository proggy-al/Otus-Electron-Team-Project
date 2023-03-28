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

            CreateMap<AreaCreateRequest, AreaCreateDto>()
                .ForMember(f => f.EmploeeId, map => map.Ignore());

            CreateMap<AreaEditRequest, AreaEditDto>()
                .ForMember(f => f.EmploeeId, map => map.Ignore());
        }
    }
}
