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
}
