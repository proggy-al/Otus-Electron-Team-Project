using GMS.Core.BusinessLogic.Contracts;

namespace GMS.Core.BusinessLogic.Abstractions
{
    public interface ITimeSlotService : IService
    {
        /// <summary>
        /// Получить список временных интервалов за день 
        /// </summary>
        /// <param name="date">дата</param>
        /// <param name="trainerId">идентификатор тренера</param>
        /// <returns>список ДТО временных интервалов</returns>
        Task<List<TimeSlotDto>> GetAllPerDay(DateOnly date, Guid trainerId);

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>ДТО</returns>
        Task<TimeSlotDto> Get(Guid id);

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="dto">ДТО</para
        /// <returns>идентификатор</returns>
        Task<Guid> Create(TimeSlotCreateDto dto);

        /// <summary>
        /// Поместить в архив
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="userId">идентификатор пользователя, который помещает в архив TimeSlot</param>
        Task AddToArchive(Guid id, Guid userId);
    }
}
