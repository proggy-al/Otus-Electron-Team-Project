using GMS.Core.BusinessLogic.Abstractions.Base;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Repositories;

namespace GMS.Core.BusinessLogic.Abstractions
{
    public interface ITimeSlotService : IBaseService<TimeSlotRepository, TimeSlot, TimeSlotDto, Guid>
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
