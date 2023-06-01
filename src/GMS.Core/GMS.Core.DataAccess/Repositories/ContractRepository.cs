using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Context;
using GMS.Core.DataAccess.Repositories.Base;
using GMS.Core.WebHost.Models;
using Microsoft.EntityFrameworkCore;

namespace GMS.Core.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий контракта
    /// </summary>
    public class ContractRepository : Repository<Contract, Guid>, IContractRepository
    {
        public ContractRepository(DatabaseContext context) : base(context) { }

        public async Task<PagedList<Contract>> GetPageAsync(Guid fitnessClubId, int pageNumber, int pageSize, bool IsApproved)
        {
            var query = GetAll(true)
                .Include(c => c.Product)
                .Where(c => c.Product.FitnessClubId == fitnessClubId && c.IsApproved == IsApproved)
                .OrderBy(x => x.StartDate);

            return new PagedList<Contract>()
            {
                Entities = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(),
                Pagination = new Pagination(query.Count(), pageNumber, pageSize)
            };
        }

        public async Task<PagedList<Contract>> GetPageByUserId(Guid userId, int pageNumber, int pageSize)
        {
            var query = GetAll(true)
                .Include(c => c.Product)
                    .ThenInclude(p => p.FitnessClub)
                .Where(c => c.UserId == userId)
                .OrderBy(x => x.EndDate);

            return new PagedList<Contract>()
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
