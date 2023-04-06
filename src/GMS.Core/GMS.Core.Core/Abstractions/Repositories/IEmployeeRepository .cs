using GMS.Core.Core.Abstractions.Repositories.Base;
using GMS.Core.Core.Domain;
using GMS.Core.WebHost.Models;

namespace GMS.Core.Core.Abstractions.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee,Guid>
    {
        /// <summary>
        /// Получить полный список идентификаторов сотрудников
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список Guid</returns>
        Task<PagedList<Guid>> GetPagedAsync(Guid fitnessClubId, int pageNumber, int pageSize);

        /// <summary>
        /// Проверить работает ли сотрудник в фитнес клубе
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="employeeId">идентификатор сотрудника</param>
        /// <returns></returns>
        Task<bool> IsEmployeeWorkingInFitnessClub(Guid fitnessClubId, Guid employeeId);
    }
}
