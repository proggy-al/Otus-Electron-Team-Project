using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Models;

namespace GMS.Core.BusinessLogic.Abstractions
{
    public interface IAreaService : IService
    {
        /// <summary>
        /// Получить постраничный список зон
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>список ДТО зон</returns>
        Task<PagedList<AreaDto>> GetPage(Guid fitnessClubId, int pageNumber, int pageSize);

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>ДТО зоны</returns>
        Task<AreaDto> Get(Guid id);

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="dto">ДТО</para
        /// <returns>идентификатор</returns>
        Task<Guid> Create(AreaCreateDto dto);

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="dto">ДТО зоны</param>
        Task Update(Guid id, AreaEditDto dto);

        /// <summary>
        /// Поместить в архив
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="employeeId">идентификатор сотрудника клуба</param>
        Task AddToArchive(Guid id, Guid employeeId);
    }
}
