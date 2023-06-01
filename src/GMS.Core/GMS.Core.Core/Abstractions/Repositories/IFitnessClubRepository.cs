using GMS.Core.Core.Abstractions.Repositories.Base;
using GMS.Core.Core.Domain;
using GMS.Core.WebHost.Models;

namespace GMS.Core.Core.Abstractions.Repositories
{
    public interface IFitnessClubRepository : IRepository<FitnessClub, Guid>
    {
        /// <summary>
        /// Получить постраничный список фитнес клубов
        /// </summary>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список фитнес клубов</returns>
        Task<PagedList<FitnessClub>> GetPagedAsync(int pageNumber, int pageSize, bool noTracking = false);

        /// <summary>
        /// Получить постраничный список фитнес клубов пользователя
        /// </summary>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список фитнес клубов</returns>
        Task<PagedList<FitnessClub>> GetPageByOwnerIdAsync(Guid userId, int pageNumber, int pageSize, bool noTracking = false);
    }
}
