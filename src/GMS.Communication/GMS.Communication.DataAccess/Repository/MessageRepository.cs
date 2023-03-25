using GMS.Communication.Core.Abstractons;
using GMS.Communication.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GMS.Communication.DataAccess.Repository
{
    public class MessageRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly GmsMessagesDb _db;
        private readonly ILogger<T> _logger;
        private readonly string _typeName;

        public MessageRepository(GmsMessagesDb db, ILogger<T> logger)
        {
            _db = db;
            _logger = logger;
            _typeName = typeof(T).Name;
        }

        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<T> CreateAsync(T entity, CancellationToken cancel = default)
        {
            _logger.LogInformation($"Creating entity of {_typeName} ...");
            _logger.LogInformation($"Checking for null ...");
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _logger.LogInformation($"Adding entity into DbContext ...");
            await _db.Set<T>().AddAsync(entity, cancel);
            _logger.LogInformation($"Saving changes ...");
            await _db.SaveChangesAsync(cancel);
            _logger.LogInformation($"Success, Id {entity.Id}");
            return entity;
        }

        /// <summary>
        /// Delete the entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancel = default)
        {
            _logger.LogInformation($"Deleting of entity ...");
            var entity = await GetByIdAsync(id, cancel);
            _logger.LogInformation($"Checking for existing ...");
            if (entity is null)
            {
                _logger.LogInformation($"Trying to delete non-existing {_typeName} - {id} ...");
                return false;
            }
            _db.Set<T>().Remove(entity);
            _logger.LogInformation($"Save changes ...");
            await _db.SaveChangesAsync(cancel);
            var result = await GetByIdAsync(id, cancel) is null;
            if (result)
                _logger.LogInformation("Failed");
            else
                _logger.LogWarning("Success");
            return result;
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<T>> GetAllAsync()
        {
            _logger.LogInformation($"Getting all entities of {_typeName}");
            return Task.FromResult<IEnumerable<T>>(_db.Set<T>().AsSplitQuery());
        }

        /// <summary>
        /// Return the entity by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancel = default)
        {
            _logger.LogInformation($"Getting Entity of {_typeName} by Id ...");
            var result = await _db.Set<T>().SingleOrDefaultAsync(e => e.Id == id, cancel);
            _logger.LogWarning(result is null ? "Failed, value is NULL" : "Success");
            return result;
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
