using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.VIewModels;

namespace GMS.Core.WebHost.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности контракта
    /// </summary>
    public class ContractVmMappingsProfile : Profile
    {
        public ContractVmMappingsProfile()
        {
            CreateMap<ContractVM, ContractDto>();
            CreateMap<ContractDto, ContractVM>();
        }
    }
}
