using GMS.Core.Core.Abstractions.Repositories.Base;
using GMS.Core.Core.Domain;
using GMS.Core.WebHost.Models;

namespace GMS.Core.Core.Abstractions.Repositories
{
    public interface IContractRepository : IRepository<Contract, Guid>
    {
        /// <summary>
        /// Получить контракты фитнес клуба
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">размер страницы</param>
        /// <param name="IsApproved">получить подтвержденные контракты или неподтвержденные</param>
        /// <returns></returns>
        Task<PagedList<Contract>> GetPageAsync(Guid fitnessClubId, int pageNumber, int pageSize, bool IsApproved);

        /// <summary>
        /// Получить контракты пользователя
        /// </summary>
        /// <param name="userId">идентификатор пользователя</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">размер страницы</param>
        /// <returns></returns>
        Task<PagedList<Contract>> GetPageByUserId(Guid userId, int pageNumber, int pageSize);
    }
}
