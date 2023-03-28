namespace GMS.Core.WebHost.Models
{
    /// <summary>
    /// ДТО контракта
    /// </summary>
    public class ContractResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Информация о продукте
        /// </summary>
        public ProductResponse Product { get; set; }

        /// <summary>
        /// Идентификатор менеджера
        /// </summary>
        public Guid ManagerId { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Информация о фитнес клубе
        /// </summary>
        public FitnessClubResponse FitnessClub { get; set; }

        /// <summary>
        /// Дата начала контракта
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата завершения контракта
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
