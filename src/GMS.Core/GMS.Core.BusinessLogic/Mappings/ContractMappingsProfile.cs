using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Domain;

namespace GMS.Core.BusinessLogic.Mappings
{
    /// <summary>
    /// Профиль автомаппера для сущности контракта
    /// </summary>
    public class ContractMappingsProfile : Profile
    {
        public ContractMappingsProfile()
        {
            CreateMap<Contract, ContractDto>();

            CreateMap<ContractDto, Contract>()
                .ForMember(d => d.FitnessClub, map => map.Ignore())
                .ForMember(d => d.Product, map => map.Ignore());
        }
    }
}
