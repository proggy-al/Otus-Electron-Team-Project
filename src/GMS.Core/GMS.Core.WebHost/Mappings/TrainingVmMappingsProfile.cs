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
            CreateMap<TrainingCreateRequest, TrainingCreateDto>()
                .ForMember(d => d.UserId, map => map.Ignore());

            CreateMap<TrainingTrainerNotesRequest, TrainingTrainerNotesDto>()
                .ForMember(d => d.TrainerId, map => map.Ignore());
        }
    }
}
