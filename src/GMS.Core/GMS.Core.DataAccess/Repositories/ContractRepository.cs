using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Context;
using GMS.Core.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace GMS.Core.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий контракта
    /// </summary>
    public class ContractRepository : Repository<Contract, Guid>, IContractRepository
    {
        public ContractRepository(DatabaseContext context) : base(context) { }

        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список контрактов</returns>
        public async Task<List<Contract>> GetPagedAsync(int page, int itemsPerPage)
        {
            var query = GetAll();
            return await query
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }

        /// <summary>
        /// Получить все сущности по идентификатору менеджера
        /// </summary>
        /// <param name="managerId">идентификатор менеджера</param>
        /// <returns>список контрактов</returns>
        public async Task<List<Contract>> GetAllByManagerIdAsync(Guid managerId)
        {
            var query = GetAll();
            return await query
                .Where(c => c.ManagerId == managerId)
                .ToListAsync();
        }

        /// <summary>
        /// Получить постраничный список по идентификатору менеджера
        /// </summary>
        /// <param name="managerId">идентификатор менеджера</param>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список контрактов</returns>
        public async Task<List<Contract>> GetPagedByManagerIdAsync(Guid managerId, int page, int itemsPerPage)
        {
            var query = GetAll();
            return await query
                .Where(c => c.ManagerId == managerId)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }

        /// <summary>
        /// Получить все сущности по идентификатору пользователя
        /// </summary>
        /// <param name="userId">идентификатор пользователя</param>
        /// <returns>список контрактов</returns>
        public async Task<List<Contract>> GetAllByUserIdAsync(Guid userId)
        {
            var query = GetAll();
            return await query
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

        /// <summary>
        /// Получить постраничный список по идентификатору пользователя
        /// </summary>
        /// <param name="userId">идентификатор пользователя</param>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список контрактов</returns>
        public async Task<List<Contract>> GetPagedByUserIdAsync(Guid userId, int page, int itemsPerPage)
        {
            var query = GetAll();
            return await query
                .Where(c => c.UserId == userId)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }
    }
}
