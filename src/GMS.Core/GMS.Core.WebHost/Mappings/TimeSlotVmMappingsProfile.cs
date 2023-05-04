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

            CreateMap<TimeSlotCreateRequest, TimeSlotCreateDto>()
                .ForMember(d => d.UserId, map => map.Ignore());
        }
    }
}
