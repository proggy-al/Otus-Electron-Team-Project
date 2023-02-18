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
            CreateMap<TimeSlot, TimeSlotDto>();

            CreateMap<TimeSlotDto, TimeSlot>()
                .ForMember(d => d.FitnessClub, map => map.Ignore())
                .ForMember(d => d.Area, map => map.Ignore())
                .ForMember(d => d.Training, map => map.Ignore());
        }
    }
}
