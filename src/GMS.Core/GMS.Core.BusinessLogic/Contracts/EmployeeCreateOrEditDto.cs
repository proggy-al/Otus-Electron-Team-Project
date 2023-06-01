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
        /// пользователь, который добавляет/редактирует сотрудника
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        public string Role { get; set; }
    }
}
