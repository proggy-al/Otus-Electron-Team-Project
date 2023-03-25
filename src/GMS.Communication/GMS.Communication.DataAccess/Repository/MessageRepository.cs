using GMS.Communication.Core.Abstractons;

namespace GMS.Communication.DataAccess.Repository
{
    public class MessageRepository<T> : IRepository<T> where T : BaseEntity
    {
        public Task<T> CreateAsync(T entity, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(Guid id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByIdAsync(Guid[] ids, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T[] entities, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
