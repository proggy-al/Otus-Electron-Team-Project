﻿using GMS.Core.Core.Abstractions.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using GMS.Core.DataAccess.Extensions;
using System.Linq.Expressions;

namespace GMS.Core.DataAccess.Repositories.Base
{
    /// <summary>
    /// Репозиторий для чтения
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    /// <typeparam name="TPrimaryKey">Основной ключ</typeparam>
    public abstract class ReadRepository<T, TPrimaryKey>
        : IReadRepository<T, TPrimaryKey> where T 
        : class, IEntity<TPrimaryKey>
    {
        protected readonly DbContext Context;
        protected DbSet<T> EntitySet;

        protected ReadRepository(DbContext context)
        {
            Context = context;
            EntitySet = Context.Set<T>();
        }

        /// <summary>
        /// Запросить все сущности в базе
        /// </summary>
        /// <param name="asNoTracking">Вызвать с AsNoTracking</param>
        /// <returns>IQueryable массив сущностей</returns>
        protected virtual IQueryable<T> GetAll(bool asNoTracking = false)
        {
            return asNoTracking ? EntitySet.AsNoTracking() : EntitySet;
        }

        public virtual async Task<T> GetAsync(TPrimaryKey id, bool asNoTracking = false)
        {
            if(!asNoTracking)
                return await EntitySet.FindAsync((object)id);
            
            return await EntitySet.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await EntitySet.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetWithIncludeAsync(Expression<Func<T, bool>> predicate, 
            params Expression<Func<T, object>>[] includeProperties)
        {
            return await EntitySet.IncludeEx(includeProperties).FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<T> GetWithInclude(Func<T, bool> predicate, 
            params Expression<Func<T, object>>[] includeProperties)
        {
            return EntitySet.AsNoTracking()
                .IncludeEx(includeProperties)
                .Where(predicate)
                .ToList();
        }
    }
}
