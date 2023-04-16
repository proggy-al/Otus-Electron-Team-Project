namespace GMS.Core.WebHost.Models
{
    public class TrainingUserResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование тренировки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание тренировки
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата и время начала тренировки
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// длительноть тренировки
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Имя тренера
        /// </summary>
        public string TrainerName { get; set; }

        /// <summary>
        /// Имя зоны
        /// </summary>
        public string FitnessClubName { get; set; }

        /// <summary>
        /// Имя зоны
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// Заметки тренера о тренировке 
        /// </summary>
        public string TrainerNotes { get; set; }

        /// <summary>
        /// Оценка за тренировку в процентах до 100%
        /// </summary>
        public int Points { get; set; }
    }
}
