using GMS.Core.Core.Abstractions.Repositories.Base;
using GMS.Core.Core.Domain;

namespace GMS.Core.Core.Abstractions.Repositories
{
    public interface IAreaRepository : IRepository<Area, Guid>
    {
        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список зон</returns>
        Task<List<Area>> GetPagedAsync(int page, int itemsPerPage);

        /// <summary>
        /// Получить все сущности по идентификатору фитнес клуба 
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <returns>список зон</returns>
        Task<List<Area>> GetAllByFitnessClubIdAsync(Guid fitnessClubId);

        /// <summary>
        /// Получить постраничный список по идентификатору фитнес клуба 
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список зон</returns>
        Task<List<Area>> GetPagedByFitnessClubIdAsync(Guid fitnessClubId, int page, int itemsPerPage);
    }
}
