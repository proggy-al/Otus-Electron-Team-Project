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

        /// <summary>
        /// Получить список временных интервалов за день 
        /// </summary>
        /// <param name="date">дата</param>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="trainerId">идентификатор тренера</param>
        /// <returns>список временных интервалов</returns>
        public async Task<List<TimeSlot>> GetAllPerDayAsync(DateOnly date, Guid fitnessClubId, Guid trainerId)
        {
            var query = GetAll();
            return await query
                .Where(t => t.DateTime.Date == date.ToDateTime(TimeOnly.MinValue) && 
                            t.FitnessClubId == fitnessClubId &&
                            t.TrainerId == trainerId)
                .ToListAsync();
        }
    }
}
