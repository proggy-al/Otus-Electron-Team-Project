using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Domain;
using GMS.Core.WebHost.Models;

namespace GMS.Core.BusinessLogic.Abstractions
{
    public interface ITrainingService : IService
    {
        /// <summary>
        /// Получить постраничный список по идентификатору пользователя
        /// </summary>
        /// <param name="userId">идентификатор пользователя</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>список ДТО тренировок</returns>
        Task<PagedList<TrainingUserDto>> GetPageByUserId(Guid userId, int pageNumber, int pageSize);

        /// <summary>
        /// Получить постраничный список прошедщих тренировок по идентификатору тренера
        /// </summary>
        /// <param name="trainerId">идентификатор тренера</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список тренировок</returns>
        Task<PagedList<TrainingTrainerDto>> GetPagedPastByTrainerId(Guid trainerId, int pageNumber, int pageSize);

        /// <summary>
        /// Получить постраничный список будущих тренировок по идентификатору тренера
        /// </summary>
        /// <param name="trainerId">идентификатор тренера</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список тренировок</returns>
        Task<PagedList<TrainingTrainerDto>> GetPagedByTrainerId(Guid trainerId, int pageNumber, int pageSize);

        /// <summary>
        /// Записаться на тренировку
        /// </summary>
        /// <param name="createDto">ДТО</param>
        /// <returns></returns>
        Task<Guid> AddTraining(TrainingCreateDto createDto);

        /// <summary>
        /// Добавить заметки тренера
        /// </summary>
        /// <param name="id">идентификатор тренировки</param>
        /// <param name="dto">ДТО</param>
        Task AddTrainerNotes(Guid id, TrainingTrainerNotesDto dto);

        /// <summary>
        /// Удалить тренировку
        /// </summary>
        /// <param name="id">идетификатор тренировки</param>
        /// <param name="userId">идентификатор пользователя</param>
        /// <param name="hoursNoLaterThan">количество часов до даты тренировки</param>
        /// <returns></returns>
        Task Cancel(Guid id, Guid userId, int hoursNoLaterThan = 24);
    }
}
