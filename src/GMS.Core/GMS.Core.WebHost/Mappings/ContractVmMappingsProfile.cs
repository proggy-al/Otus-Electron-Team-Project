using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Models;

namespace GMS.Core.WebHost.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности контракта
    /// </summary>
    public class ContractVmMappingsProfile : Profile
    {
        public ContractVmMappingsProfile()
        {
            CreateMap<ContractDto, ContractResponse>()
                .ForMember(d => d.Product, map => map.Ignore())
                .ForMember(d => d.FitnessClub, map => map.Ignore());
            CreateMap<ContractResponse, ContractDto>()
                .ForMember(d => d.IsDeleted, map => map.Ignore())
                .ForMember(d => d.IsApproved, map => map.Ignore());
        }
    }
}
