using GMS.Core.Core.Abstractions.Repositories.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Core.Core.Domain
{
    /// <summary>
    /// Модель контракта (заключается между пользователем и фитнес клубом при покупке продукта с помощью менеджера по продажам)
    /// </summary>
    public class Contract : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Продукт
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Идентификатор менеджера
        /// </summary>
        public Guid ManagerId { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Фитнес клуб
        /// </summary>
        public FitnessClub FitnessClub { get; set; }

        /// <summary>
        /// Идентификатор фитнес клуба
        /// </summary>
        public Guid FitnessClubId { get; set; }

        /// <summary>
        /// Дата начала контракта
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата завершения контракта
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Удалено
        /// </summary>
        public bool Deleted { get; set; }
    }
}
