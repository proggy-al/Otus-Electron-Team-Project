namespace GMS.Core.BusinessLogic.Contracts
{
    /// <summary>
    /// ДТО контракта
    /// </summary>
    public class ContractWithFсDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Продукт
        /// </summary>
        public ProductDto Product { get; set; }

        /// <summary>
        /// Фитнес клуб
        /// </summary>
        public FitnessClubDto FitnessClub { get; set; }

        /// <summary>
        /// Идентификатор менеджера
        /// </summary>
        public Guid ManagerId { get; set; }

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

        /// <summary>
        /// Удаленная запись доступна только для чтения
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
