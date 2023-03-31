using GMS.Core.Core.Domain.Base;

namespace GMS.Core.Core.Domain
{
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
