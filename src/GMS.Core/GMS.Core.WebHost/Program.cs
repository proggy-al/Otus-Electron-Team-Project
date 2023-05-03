using GMS.Common.Extensions;
using GMS.Core.DataAccess.Context;
using GMS.Core.WebHost.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Environment.ApplicationName = typeof(Program).Assembly.FullName;

    var connectionString = builder.Configuration.GetConnectionString("GmsCore");

    builder.Services
        .AddDbContext<DatabaseContext>(options =>
        {
            options.UseNpgsql(connectionString);
        })
        .AddRepositories()
        .AddOptions(builder.Configuration)
        .AddAutoMapper()
        .AddHttpClients()
        .AddServices()
        .AddMassTransitRabbitMQ()
        .AddRabbitMQProducers()
        .AddLogger(builder.Configuration)
        .AddEndpointsApiExplorer()
        .AddCustomJWTAuthentification()
        .AddAuthorizationGMS()
        .AddSwagger()
        .AddControllers();

    var CorsAllowedOrigins = "_myAllowSpecificOrigins";

    builder.Services.AddCors(options =>
    {
        options.AddPolicy(CorsAllowedOrigins,
            builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });

    var app = WebApplicationConfiguration.Configure(builder);

    Log.Logger.Information($"The {app.Environment.ApplicationName} started...");
    app.Run();

    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly!");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}