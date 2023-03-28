using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Models;

namespace GMS.Core.WebHost.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности временного интервала
    /// </summary>
    public class TimeSlotVmMappingsProfile : Profile
    {
        public TimeSlotVmMappingsProfile()
        {
            CreateMap<TimeSlotDto, TimeSlotResponse>();
            CreateMap<TimeSlotResponse, TimeSlotDto>()
                .ForMember(d => d.IsDeleted, map => map.Ignore())
                .ForMember(d => d.FitnessClubId, map => map.Ignore())
                .ForMember(d => d.IsBusy, map => map.Ignore());
        }
    }
}
