using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Domain;

namespace GMS.Core.BusinessLogic.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности тренировки
    /// </summary>
    public class TrainingMappingsProfile : Profile
    {
        public TrainingMappingsProfile()
        {
            CreateMap<Training, TrainingDto>();
            CreateMap<TrainingDto, Training>()
                .ForMember(d => d.TimeSlot, map => map.Ignore());
        }
    }
}
