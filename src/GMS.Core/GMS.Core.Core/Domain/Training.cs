using GMS.Core.Core.Domain.Base;

namespace GMS.Core.Core.Domain
{
    /// <summary>
    /// Модель тренировки
    /// </summary>
    public class Training : BaseEntity
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор временного интервала
        /// </summary>
        public Guid TimeSlotId { get; set; }

        /// <summary>
        /// Временной интервал 
        /// </summary>
        public virtual TimeSlot TimeSlot { get; set; }

        /// <summary>
        /// Описание результатов тренировки
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Оценка за тренировку
        /// </summary>
        public int? Points { get; set; }
    }
}
