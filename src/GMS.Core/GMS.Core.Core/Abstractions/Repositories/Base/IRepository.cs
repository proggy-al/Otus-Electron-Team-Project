namespace GMS.Core.Core.Abstractions.Repositories.Base
{
    /// <summary>
    /// Базовый интерфейс всех репозиториев
    /// </summary>
    public interface IRepository { }

    /// <summary>
    /// Описания общих методов для всех репозиториев
    /// </summary>
    /// <typeparam name="T">Тип Entity для репозитория</typeparam>
    /// <typeparam name="TPrimaryKey">тип первичного ключа</typeparam>
    public interface IRepository<T, TPrimaryKey> : IReadRepository<T, TPrimaryKey>
        where T : IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Добавить в базу одну сущность
        /// </summary>
        /// <param name="entity">сущность для добавления</param>
        /// <returns>добавленная сущность</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Для сущности проставить состояние - что она изменена
        /// </summary>
        /// <param name="entity">сущность для изменения</param>
        void Update(T entity);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="id">ID удалённой сущности</param>
        void Delete(TPrimaryKey id);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
