using GMS.Communication.Core.Abstractons;
using GMS.Communication.WebHost.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GMS.Communication.WebHost.Models
{
    public class Notificator : INotificatable
    {
        private const string MethodName = "ReceiveMessage";
        private readonly ILogger<Notificator> _logger;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IRepository<TrainingNotification> _notificationDb;
        public Notificator(ILogger<Notificator> logger, IRepository<TrainingNotification> notificationDb, IHubContext<ChatHub> hubContext)
        {
            _logger = logger;
            _notificationDb = notificationDb;
            _hubContext = hubContext;
        }

        public async Task AddNotificationAsync(TrainingNotification notification)
        {
            await _notificationDb.CreateAsync(notification);
        }

        public async Task DeleteNotificationAsync(Guid trainingId)
        {
            await _notificationDb.DeleteAsync(trainingId);
        }

        public async Task NotificateAsync(TrainingNotification notification)
        {
            if(notification.UserId is not null)
            {
               await _hubContext.Clients.User(notification.UserId.ToString()).SendAsync(MethodName, notification.Content);
            }

            if(notification.Email is not null)
            {
                //TODO Логика для email рассылки
            }
        }
    }

    public interface INotificatable
    {
        /// <summary>
        /// Добавить уведомление
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        public Task AddNotificationAsync(TrainingNotification notification);

        /// <summary>
        /// Удалить уведомление
        /// </summary>
        /// <param name="trainingId"></param>
        /// <returns></returns>
        public Task DeleteNotificationAsync(Guid trainingId);

        /// <summary>
        /// Уведомить
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        public Task NotificateAsync(TrainingNotification notification);
    }
}
