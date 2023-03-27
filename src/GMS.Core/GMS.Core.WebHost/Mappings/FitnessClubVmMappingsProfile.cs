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
            CreateMap<FitnessClubResponse, FitnessClubDto>()
                .ForMember(f => f.IsDeleted, map => map.Ignore())
                .ForMember(f => f.OwnerId, map => map.Ignore());

            CreateMap<FitnessClubCreateOrEditDto, FitnessClubCreateOrEditRequest>();
            CreateMap<FitnessClubCreateOrEditRequest, FitnessClubCreateOrEditDto>()
                .ForMember(f => f.OwnerId, map => map.Ignore());
        }
    }
}
