using GMS.Core.DataAccess.Context;
using GMS.Core.WebHost.Configurations;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Environment.ApplicationName = typeof(Program).Assembly.FullName;

    builder.Services
        .ConfigureLogger()
        .ConfigureMapper()
        .AddDbContext<DatabaseContext>()
        .AddRepositories()
        .AddServices()
        .AddEndpointsApiExplorer()
        .ConfigureSwagger()
        .AddAuthorization()
        .AddControllers();

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