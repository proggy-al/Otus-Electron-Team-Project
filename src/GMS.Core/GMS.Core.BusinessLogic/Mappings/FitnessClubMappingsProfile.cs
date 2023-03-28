﻿using AutoMapper;
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

            CreateMap<FitnessClubCreateOrEditDto, FitnessClub>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.IsDeleted, map => map.Ignore())
                .ForMember(d => d.Areas, map => map.Ignore())
                .ForMember(d => d.Products, map => map.Ignore())
                .ForMember(d => d.TimeSlots, map => map.Ignore());
        }
    }
}
