using GMS.Core.Core.Abstractions.Repositories.Base;
using System.ComponentModel.DataAnnotations.Schema;

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
        /// Идентификатор фитнес клуба
        /// </summary>
        public Guid FitnessClubId { get; set; }

        [ForeignKey("FitnessClubId")]
        public FitnessClub FitnessClub { get; set; }
    }
}
