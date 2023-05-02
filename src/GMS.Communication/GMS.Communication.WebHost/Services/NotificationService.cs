using GMS.Communication.Core.Abstractons;
using GMS.Communication.WebHost.Hubs;
using GMS.Communication.WebHost.Models;
using Microsoft.AspNetCore.SignalR;
using Timer = System.Threading.Timer;

namespace GMS.Communication.WebHost.Services
{
    public class NotificationService
    {
        private readonly Notificator _notificator;
        private Timer _timer;
        private readonly IRepository<TrainingNotification> _notificationDb;
        private const int Delta = 1;

        public NotificationService(ILogger<NotificationService> logger, Notificator notificator, IRepository<TrainingNotification> notificationDb)
        {
            _notificationDb = notificationDb;
            _notificator = notificator;
            _timer = null!;
        }

        private async Task CheckNotifications()
        {
            var result = await _notificationDb.GetByPredicateAsync(s => (
                    s.TrainingDateTime
                        .Subtract(s.NotificationPeriod)
                        .Subtract(DateTime.Now.TimeOfDay))
                .Hours <= Delta);

            foreach (var notification in result)
            {
                await _notificator.NotificateAsync(notification);
            }
        }

        public void Start(int interval = 5000)
        {
            var timerCallback = new TimerCallback(async (_) => await CheckNotifications());
            _timer = new Timer(timerCallback, null,0, interval);
        }
    }
}
