using GMS.Common.Extensions;
using MassTransit;

namespace GMS.Core.WebHost.Configurations
{
    public static class MassTransitRabbitMQConfiguration
    {
        public static IServiceCollection AddMassTransitRabbitMQ(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMassTransit(c =>
            {
                c.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureHost();
                    cfg.UseRawJsonSerializer();
                });
            });

            return serviceCollection;
        }
    }
}
