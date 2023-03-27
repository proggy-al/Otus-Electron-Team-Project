using GMS.Core.BusinessLogic.Contracts;

namespace GMS.Core.BusinessLogic.Abstractions
{
    public interface ITrainingService : IService
    {
        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>список ДТО тренировок</returns>
        Task<List<TrainingDto>> GetPage(int pageNumber, int pageSize);


        /// <summary>
        /// Получить все сущности по идентификатору пользователя
        /// </summary>
        /// <param name="userId">идентификатор пользователя</param>
        /// <returns>список ДТО тренировок</returns>
        Task<List<TrainingDto>> GetAllByUserId(Guid userId);

        /// <summary>
        /// Получить постраничный список по идентификатору пользователя
        /// </summary>
        /// <param name="userId">идентификатор пользователя</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>список ДТО тренировок</returns>
        Task<List<TrainingDto>> GetPageByUserId(Guid userId, int pageNumber, int pageSize);

        Task<List<TrainingDto>> EditTrainerNotes(Guid userId, int pageNumber, int pageSize);
    }
}
