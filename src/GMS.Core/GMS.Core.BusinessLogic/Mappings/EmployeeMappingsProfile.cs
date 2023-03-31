using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.BusinessLogic.Services;
using GMS.Core.Core.Domain;

namespace GMS.Core.BusinessLogic.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности сотрудника
    /// </summary>
    public class EmployeeMappingsProfile : Profile
    {
        public EmployeeMappingsProfile()
        {
            CreateMap<Employee, EmployeeDto>();

            CreateMap<EmployeeCreateOrEditDto, Employee>()
                .ForMember(d => d.IsDeleted, map => map.Ignore())
                .ForMember(d => d.FitnessClub, map => map.Ignore());
        }
    }
}
