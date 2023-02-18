using GMS.Core.Core.Abstractions.Repositories.Base;

namespace GMS.Core.Core.Domain
{
    /// <summary>
    /// Модель зоны (помещение в фитнес клубе)
    /// </summary>
    public class Area : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фитнес клуб
        /// </summary>
        public FitnessClub FitnessClub { get; set; }

        /// <summary>
        /// Идентификатор фитнес клуба
        /// </summary>
        public Guid FitnessClubId { get; set; }

        /// <summary>
        /// Удалено
        /// </summary>
        public bool Deleted { get; set; }


        /// <summary>
        /// Временной интервал
        /// </summary>
        public TimeSlot TimeSlot { get; set; }
    }
}
