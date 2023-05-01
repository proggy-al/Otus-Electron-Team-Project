using GMS.Communication.DataAccess.Context;
using GMS.Communication.DataAccess.Data;
using GMS.Communication.WebHost.Hubs;
using GMS.Communication.WebHost.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Web.Management.Client;

namespace GMS.Communication.WebHost
{
    public class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            
            ILogger<GmsMessagesDb> messageDbLogger = loggerFactory.CreateLogger<GmsMessagesDb>();            
            await CreateDbIfNotExist(host, messageDbLogger);
            
            ILogger<Notificator> notificatorLogger = loggerFactory.CreateLogger<Notificator>();
            await StartNotificationWorker(host, notificatorLogger);
            
            await host.RunAsync();
        }

        /// <summary>
        /// CreateHostBuilder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureLogging((context, logging) =>
            {
                logging.AddConsole();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

        /// <summary>
        /// Creates a database if it doesn't exist
        /// </summary>
        /// <param name="host"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        private static async Task CreateDbIfNotExist(IHost host, ILogger<GmsMessagesDb> logger)
        {
            await using var scope = host.Services.CreateAsyncScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<GmsMessagesDb>();
            await DbInitializer.InitializeAsync(context, logger, true);
        }

        /// <summary>
        /// Creates a database if it doesn't exist
        /// </summary>
        /// <param name="host"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        private static async Task StartNotificationWorker(IHost host, ILogger<Notificator> logger)
        {
            await using var scope = host.Services.CreateAsyncScope();
            
            var services = scope.ServiceProvider;
            //IconnectionManager chatHub = services.GetRequiredService<ConnectionManager>();            
            var Notification = new Notificator(logger, null, (IHubContext)chatHub);

            TimerCallback callback = new TimerCallback((_) => 
            { 

            });
            
        }
    }
}

