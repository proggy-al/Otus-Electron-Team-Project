using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace GMS.Core.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий тренировки
    /// </summary>
    public class TrainingRepository : Repository<Training, Guid>, ITrainingRepository
    {
        public TrainingRepository(DbContext context) : base(context)
        {

        }

        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список тренировок</returns>
        public async Task<List<Training>> GetPagedAsync(int page, int itemsPerPage)
        {
            var query = GetAll();
            return await query
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }


        /// <summary>
        /// Получить все сущности по идентификатору пользователя
        /// </summary>
        /// <param name="userId">идентификатор пользователя</param>
        /// <returns>список тренировок</returns>
        public async Task<List<Training>> GetAllByUserIdAsync(Guid userId)
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
        /// <returns>список тренировок</returns>
        public async Task<List<Training>> GetPagedByUserIdAsync(Guid userId, int page, int itemsPerPage)
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
