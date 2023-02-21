using GMS.Core.Core.Abstractions.Repositories.Base;

namespace GMS.Core.BusinessLogic.Abstractions.Base
{
    /// <summary>
    /// Интерфейс сервиса
    /// </summary>
    /// <typeparam name="TRepository">Тип репозитория для сервиса</typeparam>
    /// <typeparam name="T">Тип Entity для сервиса</typeparam>
    /// <typeparam name="TDto">тип ДТО</typeparam>
    /// <typeparam name="TPrimaryKey">тип первичного ключа</typeparam>
    public interface IBaseService<out TRepository, T, TDto, TPrimaryKey>
        where TRepository : IRepository<T, TPrimaryKey>
        where T : IEntity<TPrimaryKey>
        where TDto : class
    {
        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>ДТО</returns>
        Task<TDto> GetById(TPrimaryKey id);

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="dto">ДТО</para
        /// <returns>идентификатор</returns>
        Task<TPrimaryKey> Create(TDto dto);

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="dto">ДТО</param>
        Task Update(TPrimaryKey id, TDto dto);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id">идентификатор</param>
        Task Delete(TPrimaryKey id);
    }
}
