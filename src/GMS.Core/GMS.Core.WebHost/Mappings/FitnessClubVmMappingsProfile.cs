using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Models;

namespace GMS.Core.WebHost.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности фитнес клуба.
    /// </summary>
    public class FitnessClubVmMappingsProfile : Profile
    {
        public FitnessClubVmMappingsProfile()
        {
            CreateMap<FitnessClubDto, FitnessClubResponse>();

            CreateMap<FitnessClubCreateOrEditRequest, FitnessClubCreateDto>()
                .ForMember(f => f.OwnerId, map => map.Ignore());

            CreateMap<FitnessClubCreateOrEditRequest, FitnessClubEditDto>()
                .ForMember(f => f.UserId, map => map.Ignore());
        }
    }
}
