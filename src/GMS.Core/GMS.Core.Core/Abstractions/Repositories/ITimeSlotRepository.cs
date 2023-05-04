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
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="trainerId">идентификатор тренера</param>
        /// <returns>список временных интервалов</returns>
        Task<List<TimeSlot>> GetAllPerDayAsync(DateOnly date, Guid trainerId);

        /// <summary>
        /// Получить временный интервал до определенных даты и времени
        /// </summary>
        /// <param name="trainerId">идентификатор тренера</param>
        /// <param name="dateTime">дата и время</param>
        /// <returns>временной интервал</returns>
        Task<TimeSlot?> GetFirstBeforeDateTime(Guid trainerId, DateTime dateTime);

        /// <summary>
        /// Получить временный интервал после определенных даты и времени
        /// </summary>
        /// <param name="trainerId">идентификатор тренера</param>
        /// <param name="dateTime">дата и время</param>
        /// <returns>временной интервал</returns>
        Task<TimeSlot?> GetFirstAfterOrInDateTime(Guid trainerId, DateTime dateTime);
    }
}
