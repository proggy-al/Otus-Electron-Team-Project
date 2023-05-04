namespace GMS.Core.BusinessLogic.Contracts
{
    /// <summary>
    /// ДТО создания тренировки
    /// </summary>
    public class TrainingCreateDto
    {
        /// <summary>
        /// Идентификатор временного интервала
        /// </summary>
        public Guid TimeSlotId { get; set; }

        /// <summary>
        /// Идентификатор пользователя, который записывается на тренировку
        /// </summary>
        public Guid UserId { get; set; }
    }
}
