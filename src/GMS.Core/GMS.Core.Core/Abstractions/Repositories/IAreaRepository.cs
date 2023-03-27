using GMS.Core.Core.Abstractions.Repositories.Base;
using GMS.Core.Core.Domain;

namespace GMS.Core.Core.Abstractions.Repositories
{
    public interface IAreaRepository : IRepository<Area,Guid>
    {
        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список зон</returns>
        Task<List<Area>> GetPagedAsync(int pageNumber, int pageSize);

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
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список зон</returns>
        Task<List<Area>> GetPagedByFitnessClubIdAsync(Guid fitnessClubId, int pageNumber, int pageSize);
    }
}
