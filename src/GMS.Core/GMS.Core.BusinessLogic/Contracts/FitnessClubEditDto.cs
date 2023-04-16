namespace GMS.Core.BusinessLogic.Contracts
{
    /// <summary>
    /// ДТО редактирования фитнес клуба
    /// </summary>
    public class FitnessClubEditDto
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
        /// пользователь, который редактирует
        /// </summary>
        public Guid UserId { get; set; }
    }
}
