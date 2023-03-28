using GMS.Core.BusinessLogic.Contracts;

namespace GMS.Core.BusinessLogic.Abstractions
{
    public interface ITimeSlotService : IService
    {
        /// <summary>
        /// Получить список временных интервалов за день 
        /// </summary>
        /// <param name="date">дата</param>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="trainerId">идентификатор тренера</param>
        /// <returns>список ДТО временных интервалов</returns>
        Task<List<TimeSlotDto>> GetAllPerDay(DateOnly date, Guid fitnessClubId, Guid trainerId);
    }
}
