using GMS.Core.DataAccess.Context;
using GMS.Core.WebHost.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;

try
{
    
    var builder = WebApplication.CreateBuilder(args);
    builder.Environment.ApplicationName = typeof(Program).Assembly.FullName;

    builder.Services
        .ConfigureLogger()
        .ConfigureMapper()
        .AddRepositories()
        .AddDBContext(builder.Configuration)
        .AddServices()
        .AddBackgroundServices()
        .AddEndpointsApiExplorer()
        .ConfigureSwagger()
        .AddAuthorization()
        .AddControllers();

    var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
        options.DocExpansion(DocExpansion.None);
    });

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