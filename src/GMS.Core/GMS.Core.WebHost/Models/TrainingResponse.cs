using GMS.Core.Core.Domain;

namespace GMS.Core.WebHost.Models
{
    public class TrainingResponse
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
        /// временной интервал
        /// </summary>
        public TimeSlotResponse TimeSlot { get; set; }

        /// <summary>
        /// Описание результатов тренировки
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Оценка за тренировку в %. 100% - наивысшая оценка
        /// </summary>
        public int Points { get; set; }
    }
}
