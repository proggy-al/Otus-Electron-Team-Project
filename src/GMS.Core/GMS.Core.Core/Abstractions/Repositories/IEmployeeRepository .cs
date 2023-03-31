﻿using GMS.Core.Core.Abstractions.Repositories.Base;
using GMS.Core.Core.Domain;
using GMS.Core.WebHost.Models;

namespace GMS.Core.Core.Abstractions.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee,Guid>
    {
        /// <summary>
        /// Получить постраничный список по идентификатору фитнес клуба 
        /// </summary>
        /// <param name="fitnessClubId">идентификатор фитнес клуба</param>
        /// <param name="pageNumber">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <returns>список сотрудников</returns>
        Task<PagedList<Employee>> GetPagedAsync(Guid fitnessClubId, int pageNumber, int pageSize, bool noTracking = false);
    }
}
