using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.DataAccess.Repositories.Base;
using GMS.Core.Core.Domain;
using Microsoft.EntityFrameworkCore;
using GMS.Core.DataAccess.Context;
using GMS.Core.WebHost.Models;
using GMS.Core.Core.Domain.Employees;

namespace GMS.Core.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий менеджеров
    /// </summary>
    public class ManagerRepository : Repository<Manager, Guid>, IManagerRepository
    {
        public ManagerRepository(DatabaseContext context) : base(context) { }

        public async Task<PagedList<Guid>> GetPageAsync(Guid fitnessClubId, int pageNumber, int pageSize)
        {
            var query = GetAll(true)
                .Where(p => p.FitnessClubId == fitnessClubId && p.IsDeleted == false)
                .Select(p => p.Id);

            return new PagedList<Guid>()
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
