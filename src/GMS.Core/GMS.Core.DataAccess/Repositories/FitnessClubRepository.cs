using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Context;
using GMS.Core.DataAccess.Repositories.Base;
using GMS.Core.WebHost.Models;
using Microsoft.EntityFrameworkCore;

namespace GMS.Core.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий фитнес клуба
    /// </summary>
    public class FitnessClubRepository : Repository<FitnessClub, Guid>, IFitnessClubRepository
    {
        public FitnessClubRepository(DatabaseContext context) : base(context) { }

        public async Task<PagedList<FitnessClub>> GetPagedAsync(int pageNumber, int pageSize, bool noTracking = false)
        {
            var query = GetAll(noTracking)
                .Where(fc => fc.IsDeleted == false)
                .OrderBy(fc => fc.Name);

            return new PagedList<FitnessClub>()
            {
                Entities = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(),
                Pagination = new Pagination(query.Count(), pageNumber, pageSize)
            };
        }

        public async Task<PagedList<FitnessClub>> GetPageByOwnerIdAsync(Guid userId, int pageNumber, int pageSize, bool noTracking = false)
        {
            var query = GetAll(noTracking)
                .Where(fc => fc.OwnerId == userId && fc.IsDeleted == false)
                .OrderBy(fc => fc.Name);

            return new PagedList<FitnessClub>()
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
