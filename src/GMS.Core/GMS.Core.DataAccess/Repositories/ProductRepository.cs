using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace GMS.Core.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий продукта
    /// </summary>
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {

        }

        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список продуктов</returns>
        public async Task<List<Product>> GetPagedAsync(int page, int itemsPerPage)
        {
            var query = GetAll();
            return await query
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }

        /// <summary>
        /// Получить все сущности по идентификатору фитнес клуба 
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <returns>список продуктов</returns>
        public async Task<List<Product>> GetAllByFitnessClubIdAsync(Guid fitnessClubId)
        {
            var query = GetAll();
            return await query
                .Where(a => a.FitnessClubId == fitnessClubId)
                .ToListAsync();
        }

        /// <summary>
        /// Получить постраничный список по идентификатору фитнес клуба 
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список продуктов</returns>
        public async Task<List<Product>> GetPagedByFitnessClubIdAsync(Guid fitnessClubId, int page, int itemsPerPage)
        {
            var query = GetAll();
            return await query
                .Where(a => a.FitnessClubId == fitnessClubId)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }
    }
}
