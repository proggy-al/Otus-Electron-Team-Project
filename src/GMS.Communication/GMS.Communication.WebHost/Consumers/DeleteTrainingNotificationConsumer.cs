using AutoMapper;
using GMS.Common.Commands;
using MassTransit;

namespace GMS.Communication.WebHost.Consumers
{
    public class DeleteTrainingNotificationConsumer : IConsumer<DeleteTrainingNotificationCmd>
    {
        private readonly IMapper _mapper;

        public DeleteTrainingNotificationConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<DeleteTrainingNotificationCmd> context)
        {
            var trainingId = context.Message.TrainingId;

            // ToDo: дальнейшая логика
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
