using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Models;

namespace GMS.Core.WebHost.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности тренировки
    /// </summary>
    public class TrainingVmMappingsProfile : Profile
    {
        public TrainingVmMappingsProfile()
        {
            CreateMap<TrainingDto, TrainingResponse>()
                 .ForMember(d => d.TimeSlot, map => map.Ignore());
            CreateMap<TrainingResponse, TrainingDto>()
                .ForMember(d => d.IsDeleted, map => map.Ignore());
        }
    }
}
