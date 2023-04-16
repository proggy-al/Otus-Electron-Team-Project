using GMS.Core.Core.Abstractions.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace GMS.Core.DataAccess.Repositories.Base
{
    /// <summary>
    /// Репозиторий чтения и записи
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    /// <typeparam name="TPrimaryKey">Основной ключ</typeparam>
    public abstract class Repository<T, TPrimaryKey> 
        : ReadRepository<T, TPrimaryKey>, IRepository<T, TPrimaryKey> where T 
        : class, IEntity<TPrimaryKey>
    {
        protected Repository(DbContext context) : base(context) { }

        public virtual async Task<T> AddAsync(T entity)
        {
            return (await Context.Set<T>().AddAsync(entity)).Entity;
        }

        public virtual void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TPrimaryKey id)
        {
            var obj = EntitySet.Find(id);            
            EntitySet.Remove(obj);
        }

        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
