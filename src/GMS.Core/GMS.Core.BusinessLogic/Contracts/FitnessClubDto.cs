namespace GMS.Core.BusinessLogic.Contracts
{
    /// <summary>
    /// ДТО фитнес клуба
    /// </summary>
    public class FitnessClubDto
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
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Идентификатор владельца
        /// </summary>
        public Guid OwnerId { get; set; }

        /// <summary>
        /// Удаленная запись доступна только для чтения
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
