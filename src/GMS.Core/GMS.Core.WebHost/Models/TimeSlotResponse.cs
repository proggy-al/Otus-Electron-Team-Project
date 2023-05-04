namespace GMS.Core.WebHost.Models
{
    /// <summary>
    /// ДТО временного интервала
    /// </summary>
    public class TimeSlotResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

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
        /// Длительность тренировки
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Имя зоны
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// Статус занят/свободен
        /// </summary>
        public bool IsBusy { get; set; }
    }
}
