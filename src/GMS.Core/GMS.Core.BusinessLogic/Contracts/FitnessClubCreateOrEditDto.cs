namespace GMS.Core.BusinessLogic.Contracts
{
    /// <summary>
    /// ДТО создания фитнес клуба
    /// </summary>
    public class FitnessClubCreateOrEditDto
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Идентификатор владельца клуба
        /// </summary>
        public Guid OwnerId { get; set; }
    }
}
