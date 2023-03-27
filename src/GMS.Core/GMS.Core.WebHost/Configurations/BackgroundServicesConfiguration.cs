using GMS.Core.WebHost.BackgroundServices;

namespace GMS.Core.WebHost.Configurations
{
    public static class BackgroundServicesConfiguration
    {
        public static IServiceCollection AddBackgroundServices(this IServiceCollection services)
        {
            services.AddSingleton<RefreshInspector>();
            services.AddHostedService<RefreshInspector>(x=> x.GetService<RefreshInspector>());
            return services;
        }

    }
}
