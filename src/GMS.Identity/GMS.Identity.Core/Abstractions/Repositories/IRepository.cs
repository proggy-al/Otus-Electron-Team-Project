using GMS.Identity.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Identity.Core.Abstractions.Repositories
{
    public interface IRepository<T>
       where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> RemoveAsync(T entity);
    }
}
