using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Domain;

namespace GMS.Core.BusinessLogic.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности временного интервала
    /// </summary>
    public class TimeSlotMappingsProfile : Profile
    {
        public TimeSlotMappingsProfile()
        {
            CreateMap<TimeSlot, TimeSlotDto>().IncludeMembers(t => t.Area);
            CreateMap<Area, TimeSlotDto>(MemberList.None)
                .ForMember(t => t.AreaName, opt => opt.MapFrom(a => a.Name));

            CreateMap<TimeSlotCreateDto, TimeSlot>()
                .ForMember(t => t.Id, map => map.Ignore())
                .ForMember(t => t.IsDeleted, map => map.Ignore())
                .ForMember(t => t.IsBusy, map => map.Ignore())
                .ForMember(t => t.Area, map => map.Ignore())
                .ForMember(t => t.Trainer, map => map.Ignore())
                .ForMember(t => t.Training, map => map.Ignore());
        }
    }
}
