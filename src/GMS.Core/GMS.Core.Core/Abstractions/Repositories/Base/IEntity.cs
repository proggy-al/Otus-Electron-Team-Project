﻿namespace GMS.Core.Core.Abstractions.Repositories.Base
{
    /// <summary>
    /// Интерфейс сущности с идентификатором
    /// </summary>
    /// <typeparam name="TId">Тип идентификатора</typeparam>
    public interface IEntity<TId>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        TId Id { get; set; }

        /// <summary>
        /// Возвращает значение true, если элемент был удален
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
