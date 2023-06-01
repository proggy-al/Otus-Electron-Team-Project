using System.Linq.Expressions;

namespace GMS.Communication.Core.Abstractons
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T entity, CancellationToken cancel = default);
        /// <summary>
        /// Выборка из Generic репазитория по Predicate
        /// </summary>
        /// <param name="where"></param>
        /// <returns>Коллекция Т</returns>
        /// <remarks>
        /// Создана для получения всех сообщений пользователя
        /// </remarks>
        Task<ICollection<T>> GetByPredicateAsync(Expression<Func<T, bool>> where);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancel = default);
    }
}
