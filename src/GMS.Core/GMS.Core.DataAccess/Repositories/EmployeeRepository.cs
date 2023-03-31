using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.DataAccess.Repositories.Base;
using GMS.Core.Core.Domain;
using Microsoft.EntityFrameworkCore;
using GMS.Core.DataAccess.Context;
using GMS.Core.WebHost.Models;

namespace GMS.Core.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий сотрудников
    /// </summary>
    public class EmployeeRepository : Repository<Employee, Guid>, IEmployeeRepository
    {
        public EmployeeRepository(DatabaseContext context) : base(context) { }

        public async Task<PagedList<Employee>> GetPagedAsync(Guid fitnessClubId, int pageNumber, int pageSize, bool noTracking = false)
        {
            var query = GetAll(noTracking)
                .Where(p => p.FitnessClubId == fitnessClubId && p.IsDeleted == false);

            return new PagedList<Employee>()
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
