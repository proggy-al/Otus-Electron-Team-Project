namespace GMS.Core.WebHost.Models
{
    public class ContractCreateRequest
    {
        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор фитнес клуба
        /// </summary>
        public Guid FitnessClubId { get; set; }
    }
}
