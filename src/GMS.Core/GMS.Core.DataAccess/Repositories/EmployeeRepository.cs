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

        public async Task<PagedList<Guid>> GetPagedAsync(Guid fitnessClubId, int pageNumber, int pageSize)
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

        public async Task<bool> IsEmployeeWorkingInFitnessClub(Guid fitnessClubId, Guid employeeId)
        {
            return await EntitySet
                .AnyAsync(e => e.FitnessClubId == fitnessClubId && 
                          e.Id == employeeId && 
                          e.IsDeleted == false);
        }
    }
}
