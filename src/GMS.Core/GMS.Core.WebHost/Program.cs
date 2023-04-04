using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.DataAccess.Context;
using GMS.Core.WebHost.Configurations;
using GMS.Core.WebHost.Configurations.Options;
using JWTAuthManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

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
        .AddOptions(builder.Configuration)
        .AddRepositories()
        .AddHttpClients()
        .AddServices()
        .AddEndpointsApiExplorer()
        .AddCustomJWTAuthentification()
        .AddAuthorizationGMS()
        .ConfigureSwagger()
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