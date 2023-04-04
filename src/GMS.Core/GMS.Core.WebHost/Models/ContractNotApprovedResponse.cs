namespace GMS.Core.WebHost.Models
{
    /// <summary>
    /// Неподтвержденный контракт
    /// </summary>
    public class ContractNotApprovedResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Пользователь, который купил продукт
        /// </summary>
        public UserResponse User { get; set; }

        /// <summary>
        /// Продукт, который купил пользователь
        /// </summary>
        public ProductResponse Product { get; set; }

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
