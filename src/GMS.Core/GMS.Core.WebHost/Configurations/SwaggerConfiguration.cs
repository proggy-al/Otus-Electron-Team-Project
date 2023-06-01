using Microsoft.OpenApi.Models;
using System.Reflection;

namespace GMS.Core.WebHost.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwagger(this IServiceCollection serviceCollection)
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            serviceCollection.AddSwaggerGen(options =>
            {
                
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Description = "GMS API v1",
                    Title = "Swagger",
                    Version = "1.0.0"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.\r\nYou should get the token in GMS.Identity.WebHost and enter your token in the text input below.",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            return serviceCollection;
        }
    }
}
