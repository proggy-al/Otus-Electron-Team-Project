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

            CreateMap<AreaCreateDto, Area>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.IsDeleted, map => map.Ignore())
                .ForMember(d => d.FitnessClub, map => map.Ignore())
                .ForMember(d => d.TimeSlots, map => map.Ignore());

            CreateMap<AreaEditDto, Area>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.IsDeleted, map => map.Ignore())
                .ForMember(d => d.FitnessClubId, map => map.Ignore())
                .ForMember(d => d.FitnessClub, map => map.Ignore())
                .ForMember(d => d.TimeSlots, map => map.Ignore());
        }
    }
}
