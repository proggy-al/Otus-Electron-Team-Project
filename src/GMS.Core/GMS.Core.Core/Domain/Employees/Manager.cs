namespace GMS.Core.Core.Domain.Employees
{
    public class Manager : Employee
    {
        /// <summary>
        /// Контракты
        /// </summary>
        public virtual List<Contract> Contracts { get; set; }
    }
}
