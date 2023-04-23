namespace GMS.Communication.WebHost.Models
{
    public class TrainingNotificationCreateDTO
    {
        public Guid TrainingId { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string userName { get; set; }
        public string DateTime { get; set; }
        public string TrainingTitle { get; set; }
    }

    public class TrainingNotification
    {
        public Guid? UserId { get; set; }
        public string? Email { get; set; }
        public string Content { get; set; }
    }
}
