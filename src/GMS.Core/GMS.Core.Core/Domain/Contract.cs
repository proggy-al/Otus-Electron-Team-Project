using GMS.Core.Core.Domain.Base;
using GMS.Core.Core.Domain.Employees;

namespace GMS.Core.Core.Domain
{
    /// <summary>
    /// Модель контракта (заключается между пользователем и фитнес клубом при покупке продукта с помощью менеджера по продажам)
    /// </summary>
    public class Contract : BaseEntity
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Продукт
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// Идентификатор менеджера
        /// </summary>
        public Guid? ManagerId { get; set; }

        /// <summary>
        /// Менеджер, подтвердивший контракт
        /// </summary>
        public virtual Manager Manager { get; set; }

        /// <summary>
        /// Дата начала контракта
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата завершения контракта
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Статус подтверждения контракта
        /// </summary>
        public bool IsApproved { get; set; }
    }
}
