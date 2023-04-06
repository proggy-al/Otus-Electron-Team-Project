namespace GMS.Core.BusinessLogic.Contracts
{
    /// <summary>
    /// ДТО зоны
    /// </summary>
    public class AreaEditDto
    {   
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор сотрудника клуба
        /// </summary>
        public Guid EmployeeId { get; set; }
    }
}
