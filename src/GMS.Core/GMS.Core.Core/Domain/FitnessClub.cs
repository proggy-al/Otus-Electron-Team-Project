using GMS.Core.Core.Abstractions.Repositories.Base;

namespace GMS.Core.Core.Domain
{
    /// <summary>
    /// Модель фитнес клуба
    /// </summary>
    public class FitnessClub : IEntity<Guid>
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
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Идентификатор владельца
        /// </summary>
        public Guid OwnerId { get; set; }


        /// <summary>
        /// Зоны
        /// </summary>
        public IEnumerable<Area> Areas { get; set; }

        /// <summary>
        /// Продукты
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// Контракты
        /// </summary>
        public IEnumerable<Contract> Contracts { get; set; }

        /// <summary>
        /// Временные интервалы
        /// </summary>
        public IEnumerable<TimeSlot> TimeSlots { get; set; }
    }
}
