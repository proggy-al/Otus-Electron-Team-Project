using GMS.Core.Core.Domain.Base;

namespace GMS.Core.Core.Domain
{
    /// <summary>
    /// Модель временного интервала для бронирования тренировки в фитнес клубе в определенный промежуток времени к определенному тренеру
    /// </summary>
    public class TimeSlot : BaseEntity
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
        /// длительноть тренировки в минутах
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Идентификатор тренера
        /// </summary>
        public Guid TrainerId { get; set; }

        /// <summary>
        /// Идентификатор зоны
        /// </summary>
        public Guid AreaId { get; set; }

        /// <summary>
        /// Зона
        /// </summary>
        public virtual Area Area { get; set; }

        /// <summary>
        /// Идентификатор фитнес клуба
        /// </summary>
        public Guid FitnessClubId { get; set; }

        /// <summary>
        /// Фитнес клуб
        /// </summary>
        public virtual FitnessClub FitnessClub { get; set; }

        /// <summary>
        /// Статус занят/свободен для записи на тренировку
        /// </summary>
        public bool? IsBusy { get; set; }

        /// <summary>
        /// Тренировка
        /// </summary>
        public virtual Training Training { get; set; }
    }
}
