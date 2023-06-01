namespace GMS.Core.WebHost.Models
{
    public class ContractResponse
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
        /// Менеджер, заключивший контракт
        /// </summary>
        public ManagerResponse Manager { get; set; }

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
