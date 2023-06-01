using AutoMapper;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Domain;
using System.Net;

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

            CreateMap<Contract, ContractWithFсDto>().IncludeMembers(с => с.Product);
            CreateMap<Product, ContractWithFсDto>(MemberList.None);
        }
    }
}
