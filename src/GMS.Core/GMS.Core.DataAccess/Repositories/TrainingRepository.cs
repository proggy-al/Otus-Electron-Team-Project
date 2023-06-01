using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Context;
using GMS.Core.DataAccess.Repositories.Base;
using GMS.Core.WebHost.Models;
using Microsoft.EntityFrameworkCore;

namespace GMS.Core.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий тренировки
    /// </summary>
    public class TrainingRepository : Repository<Training, Guid>, ITrainingRepository
    {
        public TrainingRepository(DatabaseContext context) : base(context) { }

        public async Task<PagedList<Training>> GetPagedByUserIdAsync(Guid userId, int pageNumber, int pageSize)
        {
            var query = GetAll(true)
                .Include(t => t.TimeSlot)
                    .ThenInclude(t => t.Area)
                        .ThenInclude(a => a.FitnessClub)
                .Where(t => t.UserId == userId && t.TimeSlot.IsDeleted == false)
                .OrderBy(t => t.TimeSlot.DateTime);

            return new PagedList<Training>()
            {
                Entities = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(),
                Pagination = new Pagination(query.Count(), pageNumber, pageSize)
            };
        }

        public async Task<PagedList<Training>> GetPagedPastByTrainerIdAsync(Guid trainerId, int pageNumber, int pageSize)
        {
            var timeNow = DateTime.Now.ToUniversalTime();
            var query = GetAll(true)
                .Include(t => t.TimeSlot)
                    .ThenInclude(t => t.Area)
                        .ThenInclude(a => a.FitnessClub)
                .Where(t => t.TimeSlot.TrainerId == trainerId && 
                            t.TimeSlot.DateTime <= timeNow &&
                            t.TimeSlot.IsDeleted == false)
                .OrderByDescending(t => t.TimeSlot.DateTime);

            return new PagedList<Training>()
            {
                Entities = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync(),
                Pagination = new Pagination(query.Count(), pageNumber, pageSize)
            };
        }

        public async Task<PagedList<Training>> GetPagedByTrainerIdAsync(Guid trainerId, int pageNumber, int pageSize)
        {
            var timeNow = DateTime.Now.ToUniversalTime();
            var query = GetAll(true)
                .Include(t => t.TimeSlot)
                    .ThenInclude(t => t.Area)
                        .ThenInclude(a => a.FitnessClub)
                .Where(t => t.TimeSlot.TrainerId == trainerId &&
                            t.TimeSlot.DateTime > timeNow &&
                            t.TimeSlot.IsDeleted == false)
                .OrderBy(t => t.TimeSlot.DateTime);

            return new PagedList<Training>()
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
