using GMS.Identity.Core.Abstractions.Repositories;
using GMS.Identity.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Identity.DataAccess.Repositories
{
    public class UserRepository<T> : IRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
