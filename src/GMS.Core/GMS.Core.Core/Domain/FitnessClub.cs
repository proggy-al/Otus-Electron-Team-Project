using GMS.Core.Core.Domain.Base;

namespace GMS.Core.Core.Domain
{
    /// <summary>
    /// Модель фитнес клуба
    /// </summary>
    public class FitnessClub : BaseEntity
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
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid OwnerId { get; set; }

        /// <summary>
        /// Зоны
        /// </summary>
        public virtual ICollection<Area> Areas { get; set; }

        /// <summary>
        /// Продукты
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        /// <summary>
        /// Временные интервалы
        /// </summary>
        public virtual ICollection<TimeSlot> TimeSlots { get; set; }
    }
}
