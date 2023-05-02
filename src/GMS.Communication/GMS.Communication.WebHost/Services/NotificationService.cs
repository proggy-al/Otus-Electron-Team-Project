using GMS.Communication.Core.Abstractons;
using GMS.Communication.WebHost.Hubs;
using GMS.Communication.WebHost.Models;
using Microsoft.AspNetCore.SignalR;
using Timer = System.Threading.Timer;

namespace GMS.Communication.WebHost.Services
{
    public class NotificationService
    {
        private readonly Notifier _notifier;
        private Timer _timer;
        private readonly IRepository<TrainingNotification> _notificationDb;
        private const int Delta = 1;

        public NotificationService(ILogger<NotificationService> logger, Notifier notifier, IRepository<TrainingNotification> notificationDb)
        {
            _notificationDb = notificationDb;
            _notifier = notifier;
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
