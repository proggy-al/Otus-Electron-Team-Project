using GMS.Common.Options;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace GMS.Common.Extensions;

public static class RabbitMQExtensions
{
    public static IRabbitMqBusFactoryConfigurator ConfigureHost(this IRabbitMqBusFactoryConfigurator configurator)
    {
        var rabbitMqOptions = CommonConfigurationManager.Configuration.GetSection(RabbitMQOptions.Position).Get<RabbitMQOptions>();

        configurator.Host(rabbitMqOptions.Host, rabbitMqOptions.VirtualHost, hostCfg =>
        {
            hostCfg.Username(rabbitMqOptions.UserName);
            hostCfg.Password(rabbitMqOptions.Password);
        });

        return configurator;
    }
}
