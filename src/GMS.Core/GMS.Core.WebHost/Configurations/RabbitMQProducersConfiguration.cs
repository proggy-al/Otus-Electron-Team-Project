using GMS.Core.WebHost.RabbitMQProducers;
using GMS.Core.WebHost.RabbitMQProducers.Abstractions;

namespace GMS.Core.WebHost.Configurations
{
    public static class RabbitMQProducersConfiguration
    {
        public static IServiceCollection AddRabbitMQProducers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ITrainingNotificationProducer, TrainingNotificationProducer>();

            return serviceCollection;
        }
    }
}
