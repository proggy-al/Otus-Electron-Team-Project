namespace GMS.Core.BusinessLogic.Contracts
{
    /// <summary>
    /// ДТО сотрудника
    /// </summary>
    public class EmployeeDto
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
        /// Удаленная запись доступна только для чтения
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
