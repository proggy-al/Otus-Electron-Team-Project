using AutoMapper;
using GMS.Communication.Core.Domain;
using GMS.Communication.WebHost.Models;

namespace GMS.Communication.WebHost.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MessageRequestDTO, GmsMessage>().ReverseMap();
        }
    }
}
