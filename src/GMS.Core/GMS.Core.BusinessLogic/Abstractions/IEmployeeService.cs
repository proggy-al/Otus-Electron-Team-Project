using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Models;
using System.Xml.Schema;

namespace GMS.Core.BusinessLogic.Abstractions
{
    public interface IEmployeeService : IService
    {
        /// <summary>
        /// Получить постраничный список идентификаторов сотрудников фитнес клуба
        /// </summary>
        /// <param name="ownerId">идентификатор владельца клуба</param>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>список идентификаторов сотрудников</returns>
        Task<PagedList<Guid>> GetPage(Guid ownerId, Guid fitnessClubId, int pageNumber, int pageSize);

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="ownerId">идентификатор владельца клуба</param>
        /// <returns>ДТО сотрудника</returns>
        Task<EmployeeDto> Get(Guid id, Guid ownerId);

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="dto">ДТО</para
        /// <returns>идентификатор</returns>
        Task<Guid> Create(EmployeeCreateOrEditDto dto);

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="dto">ДТО</param>
        Task Update(EmployeeCreateOrEditDto dto);

        /// <summary>
        /// Поместить в архив
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="ownerId">идентификатор владельца клуба</param>
        Task AddToArchive(Guid id, Guid ownerId);
    }
}
