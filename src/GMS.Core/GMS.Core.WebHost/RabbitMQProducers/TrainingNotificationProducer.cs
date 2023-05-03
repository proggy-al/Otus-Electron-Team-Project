using GMS.Common.Commands;
using GMS.Core.WebHost.RabbitMQProducers.Abstractions;
using MassTransit;

namespace GMS.Core.WebHost.RabbitMQProducers
{
    public class TrainingNotificationProducer : ITrainingNotificationProducer
    {
        private readonly IPublishEndpoint _endPoint;

        public TrainingNotificationProducer(IPublishEndpoint endPoint) 
        {
            _endPoint = endPoint;
        }

        public async Task AddNotification(AddTrainingNotificationCmd cmd)
        {
            await _endPoint.Publish(cmd);
        }

        public async Task DeleteNotification(Guid id)
        {
            await _endPoint.Publish(new DeleteTrainingNotificationCmd(id));
        }
    }
}
