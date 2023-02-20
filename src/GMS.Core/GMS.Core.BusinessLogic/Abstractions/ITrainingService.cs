using GMS.Core.BusinessLogic.Abstractions.Base;
using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Repositories;

namespace GMS.Core.BusinessLogic.Abstractions
{
    public interface ITrainingService : IBaseService<TrainingRepository, Training, TrainingDto, Guid>
    {
        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список ДТО тренировок</returns>
        Task<List<TrainingDto>> GetPage(int page, int itemsPerPage);


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
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns>список ДТО тренировок</returns>
        Task<List<TrainingDto>> GetPageByUserId(Guid userId, int page, int itemsPerPage);
    }
}
