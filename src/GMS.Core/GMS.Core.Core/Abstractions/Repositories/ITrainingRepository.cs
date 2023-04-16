using GMS.Core.Core.Abstractions.Repositories.Base;
using GMS.Core.Core.Domain;
using GMS.Core.WebHost.Models;

namespace GMS.Core.Core.Abstractions.Repositories
{
    public interface ITrainingRepository : IRepository<Training, Guid>
    {
        /// <summary>
        /// Получить постраничный список по идентификатору пользователя
        /// </summary>
        /// <param name="userId">идентификатор пользователя</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список тренировок</returns>
        Task<PagedList<Training>> GetPagedByUserIdAsync(Guid userId, int pageNumber, int pageSize);

        /// <summary>
        /// Получить постраничный список прошедщих тренировок по идентификатору тренера
        /// </summary>
        /// <param name="trainerId">идентификатор тренера</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список тренировок</returns>
        Task<PagedList<Training>> GetPagedPastByTrainerIdAsync(Guid trainerId, int pageNumber, int pageSize);

        /// <summary>
        /// Получить постраничный список будущих тренировок по идентификатору тренера
        /// </summary>
        /// <param name="trainerId">идентификатор тренера</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список тренировок</returns>
        Task<PagedList<Training>> GetPagedByTrainerIdAsync(Guid trainerId, int pageNumber, int pageSize);
    }
}
