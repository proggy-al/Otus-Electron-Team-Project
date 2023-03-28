namespace GMS.Core.BusinessLogic.Contracts
{
    /// <summary>
    /// ДТО зоны
    /// </summary>
    public class AreaCreateDto
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
        /// Идентификатор сотрудника клуба
        /// </summary>
        public Guid EmploeeId { get; set; }
    }
}
