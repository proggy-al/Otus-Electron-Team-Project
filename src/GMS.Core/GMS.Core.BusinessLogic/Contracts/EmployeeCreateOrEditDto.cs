namespace GMS.Core.BusinessLogic.Contracts
{
    /// <summary>
    /// ДТО сотрудника
    /// </summary>
    public class EmployeeCreateOrEditDto
    {   
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор фитнес клуба
        /// </summary>
        public Guid FitnessClubId { get; set; }

        /// <summary>
        /// Идентификатор сотрудника клуба
        /// </summary>
        public Guid OwnerId { get; set; }
    }
}
