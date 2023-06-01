using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.DataAccess.Repositories.Base;
using GMS.Core.Core.Domain;
using Microsoft.EntityFrameworkCore;
using GMS.Core.DataAccess.Context;
using GMS.Core.WebHost.Models;

namespace GMS.Core.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий зоны
    /// </summary>
    public class AreaRepository : Repository<Area, Guid>, IAreaRepository
    {
        public AreaRepository(DatabaseContext context) : base(context) { }

        public async Task<PagedList<Area>> GetPagedAsync(Guid fitnessClubId, int pageNumber, int pageSize, bool noTracking = false)
        {
            var query = GetAll(noTracking)
                .Where(p => p.FitnessClubId == fitnessClubId && p.IsDeleted == false)
                .OrderBy(p => p.Name);

            return new PagedList<Area>()
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
