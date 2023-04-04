using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Models;
using GMS.Core.WebHost.Models.Identity;

namespace GMS.Core.WebHost.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности сотрудник
    /// </summary>
    public class EmployeeVmMappingsProfile : Profile
    {
        public EmployeeVmMappingsProfile()
        {
            CreateMap<UserApiModel, EmployeeResponse>();

            CreateMap<EmployeeCreateRequest, UserCreateApiModel>();
        }
    }
}
