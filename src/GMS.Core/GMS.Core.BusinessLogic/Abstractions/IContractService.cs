using GMS.Core.BusinessLogic.Contracts;
using GMS.Core.WebHost.Models;

namespace GMS.Core.BusinessLogic.Abstractions
{
    public interface IContractService : IService
    {
        /// <summary>
        /// Получить постраничный список НЕподтвержденных контрактов фитнес клуба
        /// </summary>
        /// <param name="employeeId">идентификатор сотрудника клуба</param>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>список ДТО контрактов</returns>
        Task<PagedList<ContractDto>> GetPageNotApproved(Guid employeeId, Guid fitnessClubId, int pageNumber, int pageSize);

        /// <summary>
        /// Получить постраничный список подтвержденных контрактов фитнес клуба
        /// </summary>
        /// <param name="employeeId">идентификатор сотрудника клуба</param>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>список ДТО контрактов</returns>
        Task<PagedList<ContractDto>> GetPageApproved(Guid employeeId, Guid fitnessClubId, int pageNumber, int pageSize);

        /// <summary>
        /// Получить постраничный список контрактов пользователя
        /// </summary>
        /// <param name="userId">идентификатор пользователя</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns></returns>
        Task<PagedList<ContractWithFсDto>> GetPageByUserId(Guid userId, int pageNumber, int pageSize);

        /// <summary>
        /// Создать котракт(купить продукты)
        /// </summary>
        /// <param name="productId">идентификатор продукта</param>
        /// <param name="userId">идентификатор пользователя</param>
        /// <returns></returns>
        Task<Guid> Create(Guid productId, Guid userId);

        /// <summary>
        /// Подтвердить контракт
        /// </summary>
        /// <param name="contractId">идентификатор контракта</param>
        /// <param name="employeeId">идентификатор сотрудника</param>
        /// <returns></returns>
        Task Approve(Guid contractId, Guid employeeId);
    }
}
