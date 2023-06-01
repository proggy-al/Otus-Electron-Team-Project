namespace GMS.Core.BusinessLogic.Contracts
{
    /// <summary>
    /// ДТО временного интервала
    /// </summary>
    public class TimeSlotDto
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
        /// Имя зоны
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// Статус занят/свободен для записи на тренировку
        /// </summary>
        public bool IsBusy { get; set; }

        /// <summary>
        /// Удаленная запись доступна только для чтения
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
