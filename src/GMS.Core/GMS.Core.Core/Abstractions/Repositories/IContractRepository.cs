using GMS.Core.Core.Abstractions.Repositories.Base;
using GMS.Core.Core.Domain;

namespace GMS.Core.Core.Abstractions.Repositories
{
    public interface IContractRepository : IRepository<Contract, Guid>
    {
        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список контрактов</returns>
        Task<List<Contract>> GetPagedAsync(int page, int itemsPerPage);

        /// <summary>
        /// Получить все сущности по идентификатору менеджера
        /// </summary>
        /// <param name="managerId">идентификатор менеджера</param>
        /// <returns>список контрактов</returns>
        Task<List<Contract>> GetAllByManagerIdAsync(Guid managerId);

        /// <summary>
        /// Получить постраничный список по идентификатору менеджера
        /// </summary>
        /// <param name="managerId">идентификатор менеджера</param>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список контрактов</returns>
        Task<List<Contract>> GetPagedByManagerIdAsync(Guid managerId, int page, int itemsPerPage);

        /// <summary>
        /// Получить все сущности по идентификатору пользователя
        /// </summary>
        /// <param name="userId">идентификатор пользователя</param>
        /// <returns>список контрактов</returns>
        Task<List<Contract>> GetAllByUserIdAsync(Guid userId);

        /// <summary>
        /// Получить постраничный список по идентификатору пользователя
        /// </summary>
        /// <param name="userId">идентификатор пользователя</param>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список контрактов</returns>
        Task<List<Contract>> GetPagedByUserIdAsync(Guid userId, int page, int itemsPerPage);
    }
}
