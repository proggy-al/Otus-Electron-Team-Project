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
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список контрактов</returns>
        public async Task<List<Contract>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = GetAll();
            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
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
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список контрактов</returns>
        public async Task<List<Contract>> GetPagedByManagerIdAsync(Guid managerId, int pageNumber, int pageSize)
        {
            var query = GetAll();
            return await query
                .Where(c => c.ManagerId == managerId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
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
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список контрактов</returns>
        public async Task<List<Contract>> GetPagedByUserIdAsync(Guid userId, int pageNumber, int pageSize)
        {
            var query = GetAll();
            return await query
                .Where(c => c.UserId == userId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
