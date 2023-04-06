using GMS.Core.WebHost.HttpClients;

namespace GMS.Core.WebHost.Configurations
{
    public static class HttpClientsConfiguration
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<IUserHttpClient, UserHttpClient>();
            return serviceCollection;
        }
    }
}
