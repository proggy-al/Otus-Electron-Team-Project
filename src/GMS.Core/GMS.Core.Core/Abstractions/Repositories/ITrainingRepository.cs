using GMS.Core.Core.Abstractions.Repositories.Base;
using GMS.Core.Core.Domain;

namespace GMS.Core.Core.Abstractions.Repositories
{
    public interface ITrainingRepository : IRepository<Training, Guid>
    {
        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список тренировок</returns>
        Task<List<Training>> GetPagedAsync(int pageNumber, int pageSize);


        /// <summary>
        /// Получить все сущности по идентификатору пользователя
        /// </summary>
        /// <param name="userId">идентификатор пользователя</param>
        /// <returns>список тренировок</returns>
        Task<List<Training>> GetAllByUserIdAsync(Guid userId);

        /// <summary>
        /// Получить постраничный список по идентификатору пользователя
        /// </summary>
        /// <param name="userId">идентификатор пользователя</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список тренировок</returns>
        Task<List<Training>> GetPagedByUserIdAsync(Guid userId, int pageNumber, int pageSize);
    }
}
