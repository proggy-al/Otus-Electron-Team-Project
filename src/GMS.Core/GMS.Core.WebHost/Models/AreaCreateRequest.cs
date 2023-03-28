namespace GMS.Core.WebHost.Models
{
    public class AreaCreateRequest
    {   
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор фитнес клуба
        /// </summary>
        public Guid FitnessClubId { get; set; }
    }
}
