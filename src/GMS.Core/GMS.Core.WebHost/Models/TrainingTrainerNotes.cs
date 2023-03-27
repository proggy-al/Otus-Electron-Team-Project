using GMS.Core.Core.Domain;

namespace GMS.Core.WebHost.Models
{
    public class TrainingTrainerNotes
    {
        /// <summary>
        /// идентификатор временного интервала
        /// </summary>
        public Guid TimeSlotId { get; set; }

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
