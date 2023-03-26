using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GMS.Communication.Core.Domain;

namespace GMS.Communication.Core.Abstractons
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancel = default);
        Task<IEnumerable<T>> GetByIdAsync(Guid[] ids, CancellationToken cancel = default);
        Task<T> CreateAsync(T entity, CancellationToken cancel = default);
        Task<ICollection<T>> Get(Expression<Func<T, bool>> where);
        Task UpdateAsync(T entity, CancellationToken cancel = default);
        Task UpdateAsync(T[] entities, CancellationToken cancel = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancel = default);
    }
}
