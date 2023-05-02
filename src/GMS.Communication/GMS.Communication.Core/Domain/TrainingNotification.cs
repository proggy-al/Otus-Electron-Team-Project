using GMS.Communication.Core.Abstractons;

namespace GMS.Communication.WebHost.Models
{
    /// <summary>
    /// Уведомление о тренировке
    /// </summary>
    /// <remarks>
    /// Id уведомления совпадает с Id тренировки т.к. одна тренировка один клиент
    /// </remarks>
    public class TrainingNotification: BaseEntity
    {
        // Всегда отправляется сообщение в личный кабинет
        public Guid UserId { get; set; }
        // Дата и время тренировки
        public DateTime TrainingDateTime { get; set; }
        // Время до тренировки когода произойдёт рассылка
        public DateTime NotificationPeriod { get; set; }
        // Если заполнен будет оповещение по Email
        public string? Email { get; set; }
        // Текст уведомленния
        public string Content { get; set; }
    }
}
