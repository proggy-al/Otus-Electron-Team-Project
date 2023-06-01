using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Context;
using GMS.Core.DataAccess.Repositories.Base;
using GMS.Core.WebHost.Models;
using Microsoft.EntityFrameworkCore;

namespace GMS.Core.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий продукта
    /// </summary>
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context) { }

        public async Task<PagedList<Product>> GetPagedAsync(Guid fitnessClubId, int pageNumber, int pageSize, bool noTracking = false)
        {
            var query = GetAll(noTracking)
                .Where(p => p.FitnessClubId == fitnessClubId && p.IsDeleted == false)
                .OrderBy(p => p.Quantity);

            return new PagedList<Product>()
            {
                Entities = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(),
                Pagination = new Pagination(query.Count(), pageNumber, pageSize)
            };
        }
    }
}
