using GMS.Core.Core.Abstractions.Repositories.Base;
using GMS.Core.Core.Domain.Employees;
using GMS.Core.WebHost.Models;

namespace GMS.Core.Core.Abstractions.Repositories
{
    public interface IManagerRepository : IRepository<Manager,Guid>
    {
        /// <summary>
        /// Получить постраничный список идентификаторов менеджеров
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список Guid</returns>
        Task<PagedList<Guid>> GetPageAsync(Guid fitnessClubId, int pageNumber, int pageSize);
    }
}
