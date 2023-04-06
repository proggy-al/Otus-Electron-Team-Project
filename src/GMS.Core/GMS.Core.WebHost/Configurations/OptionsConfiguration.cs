using GMS.Core.WebHost.Configurations.Options;

namespace GMS.Core.WebHost.Configurations
{
    public static class OptionsConfiguration
    {
        public static IServiceCollection AddOptions(this IServiceCollection serviceCollection, ConfigurationManager configuration)
        {
            serviceCollection.AddOptions<HttpClientOptions>()
                .Bind(configuration.GetSection(HttpClientOptions.Position));
            return serviceCollection;
        }
    }
}
