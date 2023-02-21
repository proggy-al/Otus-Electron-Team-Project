using GMS.Core.Core.Abstractions.Repositories.Base;
using GMS.Core.Core.Domain;

namespace GMS.Core.Core.Abstractions.Repositories
{
    public interface IFitnessClubRepository : IRepository<FitnessClub, Guid>
    {
        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список фитнес клубов</returns>
        Task<List<FitnessClub>> GetPagedAsync(int page, int itemsPerPage);
    }
}
