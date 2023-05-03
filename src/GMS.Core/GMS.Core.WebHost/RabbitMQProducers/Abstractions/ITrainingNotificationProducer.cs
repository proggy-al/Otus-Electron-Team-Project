using GMS.Common.Commands;

namespace GMS.Core.WebHost.RabbitMQProducers.Abstractions
{
    public interface ITrainingNotificationProducer
    {
        /// <summary>
        /// Удалить уведомление о тренировки
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteNotification(Guid id);

        /// <summary>
        /// Добавить уведомление о тренировки
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        Task AddNotification(AddTrainingNotificationCmd cmd);
    }
}
