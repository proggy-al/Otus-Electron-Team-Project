using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Services;
using GMS.Core.BusinessLogic.UseCases.Area;
using MediatR;

namespace GMS.Core.WebHost.Configurations
{
    public static class ServicesConfiguration
    {
        private const string SERVICE_NAME = "Service";

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAreaCase));
            return RegisterServices(services);
        }

        private static IServiceCollection RegisterServices(IServiceCollection services)
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
            return services;
        }
    }
}
