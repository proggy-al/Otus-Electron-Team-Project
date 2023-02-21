using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Domain;

namespace GMS.Core.BusinessLogic.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности зоны
    /// </summary>
    public class AreaMappingsProfile : Profile
    {
        public AreaMappingsProfile()
        {
            CreateMap<Area, AreaDto>();

            CreateMap<AreaDto, Area>()
                .ForMember(d => d.FitnessClub, map => map.Ignore())
                .ForMember(d => d.TimeSlot, map => map.Ignore());
        }
    }
}
