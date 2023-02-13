using GMS.Core.Core.Abstractions.Repositories.Base;
using GMS.Core.Core.Domain;

namespace GMS.Core.Core.Abstractions.Repositories
{
    public interface ITimeSlotRepository : IRepository<TimeSlot, Guid>
    {

        /// <summary>
        /// Получить список временных интервалов за день
        /// </summary>
        /// <param name="date">дата</param>
        /// <returns>список временных интервалов</returns>
        Task<List<TimeSlot>> GetAllPerDayAsync(DateOnly date);
    }
}
