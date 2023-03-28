using GMS.Core.BusinessLogic.Contracts;

namespace GMS.Core.BusinessLogic.Abstractions
{
    public interface IContractService : IService
    {
        /// <summary>
        /// Получить постраничный список контрактов менеджера
        /// </summary>
        /// <param name="managerId">идентификатор менеджера</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>список ДТО контрактов</returns>
        Task<List<ContractDto>> GetPageByManagerId(Guid managerId, int pageNumber, int pageSize);

        /// <summary>
        /// Получить постраничный список контрактов пользователя
        /// </summary>
        /// <param name="userId">идентификатор пользователя</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>список ДТО контрактов</returns>
        Task<List<ContractDto>> GetPageByUserId(Guid userId, int pageNumber, int pageSize);

        /// <summary>
        /// Получить постраничный список контрактов фитнес клуба
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">количество</param>
        /// <returns>список ДТО контрактов</returns>
        Task<List<ContractDto>> GetPageByFitnessClubId(Guid fitnessClubId, int pageNumber, int pageSize);

        Task<List<ContractDto>> GetPage(int pageNumber, int pageSize);
    }
}
