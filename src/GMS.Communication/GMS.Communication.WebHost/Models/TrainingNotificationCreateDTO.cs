using GMS.Communication.Core.Abstractons;

namespace GMS.Communication.WebHost.Models
{
    /// <summary>
    /// Запрос на создание уведомления о тренировке
    /// </summary>
    public class TrainingNotificationCreateDTO
    {        
        public Guid TrainingId { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string userName { get; set; }
        public string DateTime { get; set; }
        public string TrainingTitle { get; set; }
    }

    /// <summary>
    /// Уведомление о тренировке
    /// </summary>
    /// <remarks>
    /// Id уведомления совпадает с Id тренировки т.к. одна тренировка один клиент
    /// </remarks>
    public class TrainingNotification: BaseEntity
    {
        // Если заполнен будет сообщение в личный кабинет
        public Guid? UserId { get; set; }
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
