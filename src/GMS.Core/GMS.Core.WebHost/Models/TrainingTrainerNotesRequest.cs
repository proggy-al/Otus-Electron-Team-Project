using GMS.Core.Core.Domain;

namespace GMS.Core.WebHost.Models
{
    public class TrainingTrainerNotesRequest
    {
        /// <summary>
        /// Описание результатов тренировки
        /// </summary>
        public string TrainerNotes { get; set; }

        /// <summary>
        /// Оценка за тренировку в %. 100% - наивысшая оценка
        /// </summary>
        public int Points { get; set; }
    }
}
