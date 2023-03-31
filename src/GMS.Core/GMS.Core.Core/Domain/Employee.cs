using GMS.Core.Core.Domain.Base;

namespace GMS.Core.Core.Domain
{
    /// <summary>
    /// Сотрудник фитнес клуба
    /// </summary>
    public class Employee : BaseEntity
    {
        /// <summary>
        /// Идентификатор фитнес клуба
        /// </summary>
        public Guid FitnessClubId { get; set; }

        /// <summary>
        /// Фитнес клуб
        /// </summary>
        public virtual FitnessClub FitnessClub { get; set; }
    }
}
