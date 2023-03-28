using AutoMapper;
using GMS.Identity.Client.Models;
using GMS.Identity.Core.Domain.Administration;

namespace GMS.Identity.WebHost;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserApiModel>(); 

        CreateMap<UserApiModel, User>()
            .ForMember(d => d.Salt, map => map.Ignore())
            .ForMember(d => d.PasswordHash, map => map.Ignore());
            
        CreateMap<User, UserCreateApiModel>()
             .ForMember(d => d.Password, map => map.Ignore());

        CreateMap<UserCreateApiModel, User>()
            .ForMember(d => d.Salt, map => map.Ignore())
            .ForMember(d => d.PasswordHash, map => map.Ignore())
            .ForMember(d => d.IsActive, map => map.Ignore())
            .ForMember(d => d.Id, map => map.Ignore());

        CreateMap<User, UserPatchApiModel>()
             .ForMember(d => d.Password, map => map.Ignore());

        CreateMap<UserPatchApiModel, User>()
            .ForMember(d => d.Salt, map => map.Ignore())
            .ForMember(d => d.PasswordHash, map => map.Ignore())
            .ForMember(d => d.Id, map => map.Ignore());

        CreateMap<User, UserAuthorizeApiModel>()
            .ForMember(d => d.Password, map => map.Ignore());

        CreateMap<UserAuthorizeApiModel, User>()
            .ForMember(d => d.Email, map => map.Ignore())
            .ForMember(d => d.TelegramUserName, map => map.Ignore())
            .ForMember(d => d.Salt, map => map.Ignore())
            .ForMember(d => d.Role, map => map.Ignore())
            .ForMember(d => d.PasswordHash, map => map.Ignore())
            .ForMember(d => d.IsActive, map => map.Ignore())
            .ForMember(d => d.Id, map => map.Ignore());

        CreateMap<User, UserJwtTokenModel>();

        CreateMap<UserJwtTokenModel, User>()
            .ForMember(d => d.Salt, map => map.Ignore())
            .ForMember(d => d.PasswordHash, map => map.Ignore())
            .ForMember(d => d.IsActive, map => map.Ignore());
    }
}
