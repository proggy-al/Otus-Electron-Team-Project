namespace GMS.Core.WebHost.Models
{
    public class ContractApproveRequest
    {
        /// <summary>
        /// Идентификатор контракта
        /// </summary>
        public Guid ContractId { get; set; }

        /// <summary>
        /// Идентификатор менеджера
        /// </summary>
        public Guid ManagerId { get; set; }
    }
}
