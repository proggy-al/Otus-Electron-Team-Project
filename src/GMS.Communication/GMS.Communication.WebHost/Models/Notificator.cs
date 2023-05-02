using GMS.Communication.Core;
using GMS.Communication.Core.Abstractons;
using GMS.Communication.Core.Domain;
using GMS.Communication.DataAccess.Context;
using GMS.Communication.WebHost.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GMS.Communication.WebHost.Models
{
    //TODO Добавить логирование
    public class Notificator : INotificatable
    {
        // Константа имени метода SignalR
        private const string MethodName = "ReceiveNotification";
        private readonly ILogger<Notificator> _logger;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IRepository<TrainingNotification> _notificationDb;
        private readonly IRepository<GmsMessage> _messagesDb;

        public Notificator(ILogger<Notificator> logger, IRepository<TrainingNotification> notificationDb, IRepository<GmsMessage> messagesDb, IHubContext<ChatHub> hubContext)
        {
            _logger = logger;
            _notificationDb = notificationDb;
            _messagesDb = messagesDb;
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
            await _messagesDb.CreateAsync(new GmsMessage()
            {
                Body = notification.Content,
                CreateDate = DateTime.Now,
                DeliveryDate = null,
                ReadDate = null,
                RecipientId = notification.UserId,
                SenderId = Guid.Empty,
                Status = MessageStatus.undelivered,
                Subject = "Уведомление о тренеровке",
                Type = MessageType.text,
            });
            await _hubContext.Clients.User(notification.UserId.ToString()).SendAsync(MethodName, notification.Content);
            await _notificationDb.DeleteAsync(notification.Id);
            
            if (notification.Email is not null)
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
