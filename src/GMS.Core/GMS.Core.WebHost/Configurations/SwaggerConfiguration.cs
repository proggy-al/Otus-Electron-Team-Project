using Microsoft.OpenApi.Models;

namespace GMS.Core.WebHost.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Description = "GMS API v1",
                    Title = "Swagger", 
                    Version = "1.0.0"
                });
            });
            return serviceCollection;
        }
    }
}
