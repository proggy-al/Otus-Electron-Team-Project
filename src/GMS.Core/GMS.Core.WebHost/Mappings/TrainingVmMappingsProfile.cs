using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.VIewModels;

namespace GMS.Core.WebHost.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности тренировки
    /// </summary>
    public class TrainingVmMappingsProfile : Profile
    {
        public TrainingVmMappingsProfile()
        {
            CreateMap<TrainingVM, TrainingDto>();
            CreateMap<TrainingDto, TrainingVM>();
        }
    }
}
