using GMS.Core.Core.Domain.Base;

namespace GMS.Core.Core.Domain
{
    /// <summary>
    /// Модель продукта, который можно приобрести в фитнес клубе
    /// </summary>
    public class Product : BaseEntity
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
        /// Количество персональных тренировок
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Цена в условных единицах
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Фитнес клуб
        /// </summary>
        public FitnessClub FitnessClub { get; set; }

        /// <summary>
        /// Идентификатор фитнес клуба
        /// </summary>
        public virtual Guid FitnessClubId { get; set; }

        /// <summary>
        /// Контракты
        /// </summary>
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
