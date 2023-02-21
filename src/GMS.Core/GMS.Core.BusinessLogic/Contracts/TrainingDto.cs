namespace GMS.Core.BusinessLogic.Contracts
{
    /// <summary>
    /// ДТО тренировки
    /// </summary>
    public class TrainingDto
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
