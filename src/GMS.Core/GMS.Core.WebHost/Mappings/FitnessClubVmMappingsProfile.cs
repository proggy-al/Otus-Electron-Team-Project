using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.VIewModels;

namespace GMS.Core.WebHost.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности фитнес клуба.
    /// </summary>
    public class FitnessClubVmMappingsProfile : Profile
    {
        public FitnessClubVmMappingsProfile()
        {
            CreateMap<FitnessClubVM, FitnessClubDto>();
            CreateMap<FitnessClubDto, FitnessClubVM>();
        }
    }
}
