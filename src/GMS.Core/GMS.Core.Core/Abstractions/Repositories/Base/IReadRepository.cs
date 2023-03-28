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
        /// <param name="asNoTracking">отслеживание изменений</param>
        /// <returns></returns>
        Task<T> GetAsync(TPrimaryKey id, bool asNoTracking = false);

        /// <summary>
        /// Получить сущность по определенным условиям поиска
        /// </summary>
        /// <param name="predicate">условия поиска</param>
        /// <returns>сущность</returns>
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Получить сущность по определенным условиям поиска со связными данными
        /// </summary>
        /// <param name="predicate">условия поиска</param>
        /// <param name="includeProperties">связные данные</param>
        /// <returns>сущность</returns>
        Task<T> GetWithIncludeAsync(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Получить список сущностей по определенным условиям поиска со связными данными
        /// </summary>
        /// <param name="predicate">условия поиска</param>
        /// <param name="includeProperties">связные данные</param>
        /// <returns>Список сущностей</returns>
        IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties);
    }
}
