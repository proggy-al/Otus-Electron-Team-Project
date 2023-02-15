using GMS.Core.Core.Abstractions.Repositories.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Core.Core.Domain
{
    /// <summary>
    /// Модель тренировки
    /// </summary>
    public class Training : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Временной интервал 
        /// </summary>
        public TimeSlot TimeSlot { get; set; }

        /// <summary>
        /// Идентификатор временного интервала
        /// </summary>
        public Guid TimeSlotId { get; set; }

        /// <summary>
        /// Описание 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Оценка за тренировку
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Удалено
        /// </summary>
        public bool Deleted { get; set; }
    }
}
