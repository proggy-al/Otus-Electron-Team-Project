namespace GMS.Core.BusinessLogic.Contracts
{
    /// <summary>
    /// ДТО тренировки
    /// </summary>
    public class TrainingTrainerNotesDto
    {
        /// <summary>
        /// Заметки тренера о тренировке 
        /// </summary>
        public string TrainerNotes { get; set; }

        /// <summary>
        /// Оценка за тренировку в процентах до 100%
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Идентификатор тренера
        /// </summary>
        public Guid TrainerId { get; set; }
    }
}
