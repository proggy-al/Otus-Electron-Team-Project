using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Context;
using GMS.Core.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace GMS.Core.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий временного интервала
    /// </summary>
    public class TimeSlotRepository : Repository<TimeSlot, Guid>, ITimeSlotRepository
    {
        public TimeSlotRepository(DatabaseContext context) : base(context) { }

        public async Task<List<TimeSlot>> GetAllPerDayAsync(DateOnly date, Guid trainerId)
        {
            var query = GetAll(true);
            return await query
                .Where(t => t.TrainerId == trainerId &&
                            t.DateTime.Date.Year == date.Year &&
                            t.DateTime.DayOfYear == date.DayOfYear &&
                            t.IsDeleted == false) 
                .Include(t => t.Area)
                .OrderBy(t => t.DateTime)
            .ToListAsync();
        }

        public async Task<TimeSlot?> GetFirstBeforeDateTime(Guid trainerId, DateTime dateTime)
        {
            return await EntitySet
                .Where(t => t.TrainerId == trainerId &&
                            t.DateTime < dateTime &&
                            t.IsDeleted == false)
                .OrderByDescending(t => t.DateTime)
                .FirstOrDefaultAsync();
        }

        public async Task<TimeSlot?> GetFirstAfterOrInDateTime(Guid trainerId, DateTime dateTime)
        {
            return await EntitySet
                .Where(t => t.TrainerId == trainerId &&
                            t.DateTime >= dateTime &&
                            t.IsDeleted == false)
                .OrderBy(t => t.DateTime)
                .FirstOrDefaultAsync();
        }
    }
}
