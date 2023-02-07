using Microsoft.Extensions.DependencyInjection;

namespace GMS.Core.Core.Configurations;

public static class DICofiguration
{
    private const string SERVICE_NAME = "Service";

    public static void ServiceConfiguration(this IServiceCollection services)
    {
        RegisterServices(services);
    }

    private static void RegisterServices(IServiceCollection services)
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(t => t.IsClass && t.Name.EndsWith(SERVICE_NAME))
            .Select(t => new
            {
                Interface = t.GetInterface($"I{t.Name}"),
                Implementation = t
            }).Where(t => t.Interface != null);
        
        foreach (var type in types)
        {
            services.AddScoped(type.Interface!, type.Implementation);
        }
    }

}