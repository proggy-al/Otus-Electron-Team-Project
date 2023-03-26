using GMS.Identity.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Identity.Core.Abstractions.Repositories
{
    public interface ICoachRepository:IUserRepository
    {
        /// <summary>
        /// Get coach by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<UserApiModel?> GetCoach(Guid id);
        /// <summary>
        /// Get all coaches
        /// </summary>
        /// <returns></returns>
        public Task<List<UserApiModel>> GetCoaches();
    }
}
