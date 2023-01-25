using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace GMS.Identity.WebHost.Infrastructure;

public class SwaggerOptions
{
    public static Action<SwaggerGenOptions> SwaggerGenOptions(SwaggerGenOptions options,IConfiguration configuration)
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        
        return options =>
        {
            options.SwaggerDoc(configuration.GetSection("SwaggerOptions:Doc:Name").Value, new OpenApiInfo { Title = configuration.GetSection("SwaggerOptions:Doc:OpenApiInfo:Title").Value, Version = configuration.GetSection("SwaggerOptions:Doc:OpenApiInfo:Version").Value });

            options.AddSecurityDefinition(configuration.GetSection("SwaggerOptions:SecurityDefinition:Name").Value, new OpenApiSecurityScheme()
            {
                Name = configuration.GetSection("SwaggerOptions:SecurityDefinition:OpenApiSecurityScheme:Name").Value,
                Type = (SecuritySchemeType)(int.Parse(configuration.GetSection("SwaggerOptions:SecurityDefinition:OpenApiSecurityScheme:Type").Value)),
                Scheme = configuration.GetSection("SwaggerOptions:SecurityDefinition:OpenApiSecurityScheme:Scheme").Value,
                BearerFormat = configuration.GetSection("SwaggerOptions:SecurityDefinition:OpenApiSecurityScheme:BearerFormat").Value,
                In = (ParameterLocation)(int.Parse(configuration.GetSection("SwaggerOptions:SecurityDefinition:OpenApiSecurityScheme:In").Value)),
                Description = configuration.GetSection("SwaggerOptions:SecurityDefinition:OpenApiSecurityScheme:Description").Value
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement {
             {
                      new OpenApiSecurityScheme {Reference = new OpenApiReference {
                          Type = (ReferenceType)(int.Parse(configuration.GetSection("SwaggerOptions:SecurityRequirement:OpenApiSecurityScheme:OpenApiReference:Type").Value)),
                          Id = configuration.GetSection("SwaggerOptions:SecurityRequirement:OpenApiSecurityScheme:OpenApiReference:Id").Value}},
                      new string[] {}
             }
            });

            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

        };
        

    }
}
