using GMS.Core.BusinessLogic.Abstractions.Base;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Repositories;

namespace GMS.Core.BusinessLogic.Abstractions
{
    public interface IContractService : IBaseService<ContractRepository, Contract, ContractDto, Guid>
    {
        /// <summary>
        /// Получить список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список ДТО контракта</returns>
        Task<List<ContractDto>> GetPage(int page, int itemsPerPage);

        /// <summary>
        /// Получить все сущности по идентификатору менеджера
        /// </summary>
        /// <param name="managerId">идентификатор менеджера</param>
        /// <returns>список ДТО контрактов</returns>
        Task<List<ContractDto>> GetAllByManagerId(Guid managerId);

        /// <summary>
        /// Получить постраничный список по идентификатору менеджера
        /// </summary>
        /// <param name="managerId">идентификатор менеджера</param>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список ДТО контрактов</returns>
        Task<List<ContractDto>> GetPageByManagerId(Guid managerId, int page, int itemsPerPage);

        /// <summary>
        /// Получить все сущности по идентификатору пользователя
        /// </summary>
        /// <param name="userId">идентификатор пользователя</param>
        /// <returns>список ДТО контрактов</returns>
        Task<List<ContractDto>> GetAllByUserId(Guid userId);

        /// <summary>
        /// Получить постраничный список по идентификатору пользователя
        /// </summary>
        /// <param name="userId">идентификатор пользователя</param>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список ДТО контрактов</returns>
        Task<List<ContractDto>> GetPageByUserId(Guid userId, int page, int itemsPerPage);
    }
}
