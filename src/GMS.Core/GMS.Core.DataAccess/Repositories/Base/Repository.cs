using GMS.Core.Core.Abstractions.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
        public Guid Test { get; set; }

        protected Repository(DbContext context) : base(context) { Test = Guid.NewGuid(); }

        /// <summary>
        /// Добавить в базу одну сущность
        /// </summary>
        /// <param name="entity">сущность для добавления</param>
        /// <returns>добавленная сущность</returns>
        public virtual async Task<T> AddAsync(T entity)
        {
            return (await Context.Set<T>().AddAsync(entity)).Entity;
        }

        /// <summary>
        /// Для сущности проставить состояние - что она изменена
        /// </summary>
        /// <param name="entity">сущность для изменения</param>
        public virtual void Update(T entity)
        {
            Context.Update(entity);
        }

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="id">ID удалённой сущности</param>
        /// <returns>была ли сущность удалена</returns>
        public virtual bool Delete(TPrimaryKey id)
        {
            var obj = EntitySet.Find(id);
            if (obj == null)
                return false;
            
            EntitySet.Remove(obj);
            return true;
        }

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
