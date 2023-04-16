namespace GMS.Core.BusinessLogic.Contracts
{
    /// <summary>
    /// ДТО создания временного интервала
    /// </summary>
    public class TimeSlotCreateDto
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
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
        /// Идентификатор тренера
        /// </summary>
        public Guid TrainerId { get; set; }

        /// <summary>
        /// Идентификатор зонй
        /// </summary>
        public Guid AreaId { get; set; }

        /// <summary>
        /// Идентификатор пользователя, который создает timeSlot
        /// </summary>
        public Guid UserId { get; set; }
    }
}
