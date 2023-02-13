using GMS.Core.Core.Abstractions.Repositories.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Core.Core.Domain
{
    /// <summary>
    /// Модель продукта, который можно приобрести в фитнес клубе
    /// </summary>
    public class Product : IEntity<Guid>
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
        /// Количество (тренировок в пакете персональных тренировок, дней в абонементе на свободное посещение, минут в абонементе на солярий)
        /// </summary>
        public uint Quantity { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public uint Price { get; set; }

        /// <summary>
        /// Идентификатор фитнес клуба
        /// </summary>
        public Guid FitnessClubId { get; set; }

        [ForeignKey("FitnessClubId")]
        public FitnessClub FitnessClub { get; set; }
    }
}
