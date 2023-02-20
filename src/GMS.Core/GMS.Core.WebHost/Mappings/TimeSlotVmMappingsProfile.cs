using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.VIewModels;

namespace GMS.Core.WebHost.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности временного интервала
    /// </summary>
    public class TimeSlotVmMappingsProfile : Profile
    {
        public TimeSlotVmMappingsProfile()
        {
            CreateMap<TimeSlotVM, TimeSlotDto>();
            CreateMap<TimeSlotDto, TimeSlotVM>();
        }
    }
}
