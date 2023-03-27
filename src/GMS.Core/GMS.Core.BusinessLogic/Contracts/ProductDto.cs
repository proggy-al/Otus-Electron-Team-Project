namespace GMS.Core.BusinessLogic.Contracts
{
    /// <summary>
    /// ДТО продукта
    /// </summary>
    public class ProductDto
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
        /// Количество (тренировок в пакете персональных тренировок, дней в абонементе на свободное посещение, минут в абонементе на солярий)
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Идентификатор фитнес клуба
        /// </summary>
        public Guid FitnessClubId { get; set; }

        /// <summary>
        /// Удаленная запись доступна только для чтения
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
