using GMS.Core.WebHost.Attributes;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace GMS.Core.WebHost.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return RegisterServices(services);
        }

        private static IServiceCollection RegisterServices(IServiceCollection services)
        {

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => t.GetCustomAttribute<InjectAttribute>() is not null)
                .Select(t=> ServiceDescriptor.Describe(
                    t.GetInterfaces().First(i=> i.Name.EndsWith(t.Name)),
                    t,
                    t.GetCustomAttribute<InjectAttribute>().LifeTime))
                .ToArray();

            foreach (var type in types)
            {
                services.TryAdd(type);
            }
            return services;
        }
    }
}
