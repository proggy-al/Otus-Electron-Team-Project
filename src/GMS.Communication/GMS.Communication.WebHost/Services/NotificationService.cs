using GMS.Communication.Core.Abstractons;
using GMS.Communication.WebHost.Hubs;
using GMS.Communication.WebHost.Models;
using Microsoft.AspNetCore.SignalR;
using Timer = System.Threading.Timer;

namespace GMS.Communication.WebHost.Services
{
    /// <summary>
    /// Сервис отправки сообщений уведомления о тренировке
    /// </summary>
    public class NotificationService
    {
        private readonly Notifier _notifier;
        private Timer _timer;
        private readonly IRepository<TrainingNotification> _notificationDb; 

        public NotificationService(ILogger<NotificationService> logger, Notifier notifier, IRepository<TrainingNotification> notificationDb)
        {
            _notificationDb = notificationDb;
            _notifier = notifier;
            _timer = null!;
        }

        /// <summary>
        /// Перебор уведомлений в БД с отправкой по истекшему периоду
        /// </summary>
        /// <returns></returns>
        private async Task CheckNotifications()
        {
            var today = DateTime.Now;
            var result = await _notificationDb.GetByPredicateAsync(s => (s.TrainingDateTime - s.NotificationPeriod).Hours <= DateTime.Now.Hour);

            foreach (var notification in result)
            {
                await _notifier.NotificateAsync(notification);
            }
        }

        public void Start(int interval = 5000)
        {
            var timerCallback = new TimerCallback(async (_) => await CheckNotifications());
            _timer = new Timer(timerCallback, null,0, interval);
        }
    }
}
