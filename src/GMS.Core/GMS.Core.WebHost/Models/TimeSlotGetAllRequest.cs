namespace GMS.Core.WebHost.Models
{
    /// <summary>
    /// ДТО временного интервала
    /// </summary>
    public class TimeSlotGetAllRequest
    {
        /// <summary>
        /// Дата и время начала тренировки
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Идентификатор тренера
        /// </summary>
        public Guid TrainerId { get; set; }
    }
}
