using GMS.Core.DataAccess.Context;
using GMS.Core.WebHost.Configurations;
using JWTAuthManager;
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
        .ConfigureMapper()
        .AddHttpClients()
        .AddServices()
        .ConfigureLogger(builder.Configuration)
        .AddEndpointsApiExplorer()
        .AddCustomJWTAuthentification()
        .AddAuthorizationGMS()
        .ConfigureSwagger()
        .AddControllers();

    var app = WebApplicationConfiguration.Configure(builder);

    Log.Logger.Information($"The {app.Environment.ApplicationName} started...");
    app.UseCors(options =>
    {
        options.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed(x => true);
    });
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