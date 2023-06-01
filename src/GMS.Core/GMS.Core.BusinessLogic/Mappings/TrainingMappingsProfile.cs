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
            CreateMap<Training, TrainingUserDto>().IncludeMembers(t => t.TimeSlot, t => t.TimeSlot.Area, t => t.TimeSlot.Area.FitnessClub)
                .ForMember(t => t.IsDeleted, map => map.Ignore());
            CreateMap<TimeSlot, TrainingUserDto>(MemberList.None);
            CreateMap<Area, TrainingUserDto>(MemberList.None)
                .ForMember(t => t.AreaName, opt => opt.MapFrom(a => a.Name));
            CreateMap<FitnessClub, TrainingUserDto>(MemberList.None)
                .ForMember(t => t.FitnessClubName, opt => opt.MapFrom(f => f.Name));

            CreateMap<Training, TrainingTrainerDto>().IncludeMembers(t => t.TimeSlot, t => t.TimeSlot.Area, t => t.TimeSlot.Area.FitnessClub)
                .ForMember(t => t.IsDeleted, map => map.Ignore());
            CreateMap<TimeSlot, TrainingTrainerDto>(MemberList.None);
            CreateMap<Area, TrainingTrainerDto>(MemberList.None)
                .ForMember(t => t.AreaName, opt => opt.MapFrom(a => a.Name));
            CreateMap<FitnessClub, TrainingTrainerDto>(MemberList.None)
                .ForMember(t => t.FitnessClubName, opt => opt.MapFrom(f => f.Name));

            CreateMap<TrainingCreateDto, Training>()
                .ForMember(t => t.Id, map => map.Ignore())
                .ForMember(t => t.TrainerNotes, map => map.Ignore())
                .ForMember(t => t.Points, map => map.Ignore())
                .ForMember(t => t.TimeSlot, map => map.Ignore())
                .ForMember(t => t.IsDeleted, map => map.Ignore());

            CreateMap<TrainingTrainerNotesDto, Training>()
                .ForMember(t => t.Id, map => map.Ignore())
                .ForMember(t => t.UserId, map => map.Ignore())
                .ForMember(t => t.TimeSlotId, map => map.Ignore())
                .ForMember(t => t.TimeSlot, map => map.Ignore())
                .ForMember(t => t.IsDeleted, map => map.Ignore());
        }
    }
}
