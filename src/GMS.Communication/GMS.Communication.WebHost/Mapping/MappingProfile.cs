using AutoMapper;
using GMS.Common.Commands;
using GMS.Communication.Core.Domain;
using GMS.Communication.WebHost.Models;

namespace GMS.Communication.WebHost.Mapping
{
    public class MappingProfile : Profile
    {
        private const int TimeBefore = 24;
        public MappingProfile()
        {
            CreateMap<MessageRequestDTO, GmsMessage>().ReverseMap();
            CreateMap<AddTrainingNotificationCmd, TrainingNotification>()
                .ForMember(s => s.Id, source => source.MapFrom(c => c.TrainingId))
                .ForMember(s => s.NotificationDateTime, source => source.MapFrom(c => c.DateTime.Subtract(TimeSpan.FromHours(TimeBefore))))
                .ForMember(s => s.Email, source => source.MapFrom(c => c.Email))
                .ForMember(s => s.UserId, source => source.MapFrom(c => c.UserId))
                .ForMember(s => s.Content, source => source.MapFrom(c => $"Уважаем-ый(ая) {c.UserName}, ваша тренировка {c.TrainingName} начнётся через {TimeBefore} ч."));
        }
    }
}
