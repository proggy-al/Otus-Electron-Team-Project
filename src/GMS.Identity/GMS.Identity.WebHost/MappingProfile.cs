using AutoMapper;
using GMS.Identity.Client.Models;
using GMS.Identity.Core.Domain.Administration;

namespace GMS.Identity.WebHost;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserApiModel>();
        CreateMap<UserApiModel, User>();
        CreateMap<User, UserCreateApiModel>();
        CreateMap<UserCreateApiModel, User>();
        CreateMap<User, UserPatchApiModel>();
        CreateMap<UserPatchApiModel, User>();
        CreateMap<User, UserAuthorizeApiModel>();
        CreateMap<UserAuthorizeApiModel, User>();
        CreateMap<User, UserJwtTokenModel>();
        CreateMap<UserJwtTokenModel, User>();
    }
}
