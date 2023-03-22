using GMS.Core.DataAccess.Context;
using GMS.Core.WebHost.Configurations;
using JWTAuthManager;
using Microsoft.EntityFrameworkCore;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Environment.ApplicationName = typeof(Program).Assembly.FullName;
    
    var connectionString = builder.Configuration.GetConnectionString("GmsCore");
    builder.Services
        .ConfigureLogger()
        .ConfigureMapper()
        .AddDbContext<DatabaseContext>(options =>
        {
            options.UseNpgsql(connectionString);
        })
        .AddRepositories()
        .AddServices()
        .AddEndpointsApiExplorer()
        .ConfigureSwagger()
        .AddControllers();

    builder.Services.AddCustomJWTAuthentification();


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