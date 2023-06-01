namespace GMS.Core.WebHost.Models
{
    public class ContractUserResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Продукт, который купил пользователь
        /// </summary>
        public ProductResponse Product { get; set; }

        /// <summary>
        /// Фитнес клуб в котором куплен продукт
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
