using GMS.Core.Core.Abstractions.Repositories.Base;
using GMS.Core.Core.Domain;

namespace GMS.Core.Core.Abstractions.Repositories
{
    public interface ITrainingRepository : IRepository<Training, Guid>
    {
        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список тренировок</returns>
        Task<List<Training>> GetPagedAsync(int page, int itemsPerPage);


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
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список тренировок</returns>
        Task<List<Training>> GetPagedByUserIdAsync(Guid userId, int page, int itemsPerPage);
    }
}
