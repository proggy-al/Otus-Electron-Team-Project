using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Domain;

namespace GMS.Core.BusinessLogic.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности фитнес клуба.
    /// </summary>
    public class FitnessClubMappingsProfile : Profile
    {
        public FitnessClubMappingsProfile()
        {
            CreateMap<FitnessClub, FitnessClubDto>();

            CreateMap<FitnessClubDto, FitnessClub>()
                .ForMember(d => d.Areas, map => map.Ignore())
                .ForMember(d => d.Products, map => map.Ignore())
                .ForMember(d => d.Contracts, map => map.Ignore())
                .ForMember(d => d.TimeSlots, map => map.Ignore());
        }
    }
}
