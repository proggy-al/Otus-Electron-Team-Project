using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Models;

namespace GMS.Core.BusinessLogic.Abstractions
{
    public interface IFitnessClubService : IService
    {
        /// <summary>
        /// Получить список всех фитнес клубов
        /// </summary>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>список ДТО фитнес клуба</returns>
        Task<PagedList<FitnessClubDto>> GetPage(int pageNumber, int pageSize);

        /// <summary>
        /// Получить список фитнес клубов пользователя
        /// </summary>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>список ДТО фитнес клуба</returns>
        Task<PagedList<FitnessClubDto>> GetPageByOwnerId(Guid ownerId, int pageNumber, int pageSize);

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>ДТО фитнес клуба</returns>
        Task<FitnessClubDto> Get(Guid id);

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="dto">ДТО</para
        /// <returns>идентификатор</returns>
        Task<Guid> Create(FitnessClubCreateOrEditDto dto);

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="dto">ДТО фитнес клуба</param>
        Task Update(Guid id, FitnessClubCreateOrEditDto dto);

        /// <summary>
        /// Поместить в архив
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param userId="id">идентификатор пользователя</param>
        Task AddToArchive(Guid id, Guid userId);
    }
}
