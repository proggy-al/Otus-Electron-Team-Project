using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Context;
using GMS.Core.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace GMS.Core.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий тренировки
    /// </summary>
    public class TrainingRepository : Repository<Training, Guid>, ITrainingRepository
    {
        public TrainingRepository(DatabaseContext context) : base(context) { }

        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список тренировок</returns>
        public async Task<List<Training>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = GetAll();
            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
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
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список тренировок</returns>
        public async Task<List<Training>> GetPagedByUserIdAsync(Guid userId, int pageNumber, int pageSize)
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
