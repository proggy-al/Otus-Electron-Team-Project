using GMS.Core.Core.Abstractions.Repositories.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Core.Core.Domain
{
    /// <summary>
    /// Модель временного интервала для бронирования тренировки в фитнес клубе в определенный промежуток времени к определенному тренеру
    /// </summary>
    public class TimeSlot : IEntity<Guid>
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
        /// Зона
        /// </summary>
        public Area Area { get; set; }

        /// <summary>
        /// Идентификатор зоны
        /// </summary>
        public Guid AreaId { get; set; }

        /// <summary>
        /// Фитнес клуб
        /// </summary>
        public FitnessClub FitnessClub { get; set; }

        /// <summary>
        /// Идентификатор фитнес клуба
        /// </summary>
        public Guid FitnessClubId { get; set; }

        /// <summary>
        /// Удалено
        /// </summary>
        public bool Deleted { get; set; }


        /// <summary>
        /// Тренировка
        /// </summary>
        public Training Training { get; set; }
    }
}
