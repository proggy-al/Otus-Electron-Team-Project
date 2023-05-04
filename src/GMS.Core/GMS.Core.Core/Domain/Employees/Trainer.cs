namespace GMS.Core.Core.Domain.Employees
{
    public class Trainer : Employee
    {
        /// <summary>
        /// Временные интервалы тренировок
        /// </summary>
        public virtual List<TimeSlot> TimeSlots { get; set; }
    }
}
