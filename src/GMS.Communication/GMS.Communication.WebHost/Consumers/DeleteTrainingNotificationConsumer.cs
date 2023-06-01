using AutoMapper;
using GMS.Common.Commands;
using GMS.Communication.WebHost.Models;
using MassTransit;

namespace GMS.Communication.WebHost.Consumers
{
    public class DeleteTrainingNotificationConsumer : IConsumer<DeleteTrainingNotificationCmd>
    {
        private readonly IMapper _mapper;
        private readonly INotificatable _notifier;

        public DeleteTrainingNotificationConsumer(IMapper mapper, INotificatable notifier)
        {
            _mapper = mapper;
            _notifier = notifier;
        }

        public async Task Consume(ConsumeContext<DeleteTrainingNotificationCmd> context)
        {
            var trainingId = context.Message.TrainingId;
            await _notifier.DeleteNotificationAsync(trainingId);
        }
    }

    /* 
     // переопределение конфигурации
     public class DeleteTrainingNotificationConsumerDefenition : ConsumerDefinition<DeleteTrainingNotificationConsumer>
     {
         public DeleteTrainingNotificationConsumerDefenition()
         {
             //EndpointName = "DeleteTraining";    // имя очереди
             ConcurrentMessageLimit = 5;         // ограничение количества сообщений, потребляемых одновременно
         }

         protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<DeleteTrainingNotificationConsumer> consumerConfigurator)
         {
             endpointConfigurator.UseMessageRetry(r => r.Intervals(100, 200, 500, 800, 1000));
             endpointConfigurator.UseTimeout(x => x.Timeout = TimeSpan.FromSeconds(60));
         }
     }*/
}
