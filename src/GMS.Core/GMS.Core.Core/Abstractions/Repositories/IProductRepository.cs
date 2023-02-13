using GMS.Core.Core.Abstractions.Repositories.Base;
using GMS.Core.Core.Domain;

namespace GMS.Core.Core.Abstractions.Repositories
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список продуктов</returns>
        Task<List<Product>> GetPagedAsync(int page, int itemsPerPage);

        /// <summary>
        /// Получить все сущности по идентификатору фитнес клуба 
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <returns>список продуктов</returns>
        Task<List<Product>> GetAllByFitnessClubIdAsync(Guid fitnessClubId);

        /// <summary>
        /// Получить постраничный список по идентификатору фитнес клуба 
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список продуктов</returns>
        Task<List<Product>> GetPagedByFitnessClubIdAsync(Guid fitnessClubId, int page, int itemsPerPage);
    }
}
