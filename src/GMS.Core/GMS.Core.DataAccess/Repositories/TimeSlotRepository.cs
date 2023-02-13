using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace GMS.Core.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий временного интервала
    /// </summary>
    public class TimeSlotRepository : Repository<TimeSlot, Guid>, ITimeSlotRepository
    {
        public TimeSlotRepository(DbContext context) : base(context)
        {

        }

        /// <summary>
        /// Получить список временных интервалов за день
        /// </summary>
        /// <param name="date">дата</param>
        /// <returns>список временных интервалов</returns>
        public async Task<List<TimeSlot>> GetAllPerDayAsync(DateOnly date)
        {
            var query = GetAll();
            return await query
                .Where(t => t.DateTime.Date == date.ToDateTime(TimeOnly.MinValue))
                .ToListAsync();
        }
    }
}
