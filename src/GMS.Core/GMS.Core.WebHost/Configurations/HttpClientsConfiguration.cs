using GMS.Core.WebHost.HttpClients;
using GMS.Core.WebHost.HttpClients.Abstractions;

namespace GMS.Core.WebHost.Configurations
{
    public static class HttpClientsConfiguration
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<IUserHttpClient, UserHttpClient>();
            serviceCollection.AddHttpClient<ICoachHttpClient, CoachHttpClient>();
            return serviceCollection;
        }
    }
}
