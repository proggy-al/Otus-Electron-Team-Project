using GMS.Core.Core.Domain.Base;

namespace GMS.Core.Core.Domain
{
    /// <summary>
    /// Модель зоны (помещение в фитнес клубе)
    /// </summary>
    public class Area : BaseEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор фитнес клуба
        /// </summary>
        public Guid FitnessClubId { get; set; }        
        
        /// <summary>
        /// Фитнес клуб
        /// </summary>
        public virtual FitnessClub FitnessClub { get; set; }

        /// <summary>
        /// Временной интервал
        /// </summary>
        public virtual TimeSlot TimeSlot { get; set; }
    }
}
