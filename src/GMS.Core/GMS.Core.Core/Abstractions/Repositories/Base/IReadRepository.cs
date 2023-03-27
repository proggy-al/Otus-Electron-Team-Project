using System.Linq.Expressions;

namespace GMS.Core.Core.Abstractions.Repositories.Base
{
    /// <summary>
    /// Интерфейс репозитория, предназначенного для чтения
    /// </summary>
    /// <typeparam name="T">Тип Entity для репозитория</typeparam>
    /// <typeparam name="TPrimaryKey">тип первичного ключа</typeparam>
    public interface IReadRepository<T, TPrimaryKey> : IRepository where T : IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Получить сущность по ID
        /// </summary>
        /// <param name="id">ID сущности</param>
        /// <returns>сущность</returns>
        Task<T> GetAsync(TPrimaryKey id);

        Task<T> GetAsNoTrackingAsync(TPrimaryKey id);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<T> FirstOrDefaultAsyncWithInclude(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties);
    }
}
