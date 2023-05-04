using GMS.Communication.Core.Abstractons;
using GMS.Communication.Core.Domain;
using GMS.Communication.DataAccess.Context;
using GMS.Communication.DataAccess.Data;
using GMS.Communication.WebHost.Hubs;
using GMS.Communication.WebHost.Models;
using GMS.Communication.WebHost.Services;
using Microsoft.AspNetCore.SignalR;

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
            
            ILogger<CommunicationDb> messageDbLogger = loggerFactory.CreateLogger<CommunicationDb>();            
            await CreateDbIfNotExist(host, messageDbLogger);
            
            ILogger<Notifier> notifierLogger = loggerFactory.CreateLogger<Notifier>();
            ILogger<NotificationService> notificationServiceLogger = loggerFactory.CreateLogger<NotificationService>();
            await StartNotificationWorker(host, notifierLogger, notificationServiceLogger);
            
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
        /// Создаём базу данных если она ещё не создана.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        private static async Task CreateDbIfNotExist(IHost host, ILogger<CommunicationDb> logger)
        {
            await using var scope = host.Services.CreateAsyncScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<CommunicationDb>();
            await DbInitializer.InitializeAsync(context, logger, false);
        }

        /// <summary>
        /// Запускаем фоновый процесс для уведомелния о тернировках
        /// </summary>
        /// <param name="host"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        private static async Task StartNotificationWorker(IHost host, ILogger<Notifier> notifierlogger, ILogger<NotificationService> notificationServiceLogger)
        {
            await using var scope = host.Services.CreateAsyncScope();
            
            var services = scope.ServiceProvider;

            var hubContext = services.GetRequiredService<IHubContext<ChatHub>>();
            var notificationDb = services.GetRequiredService<IRepository<TrainingNotification>>();
            var messagesDb = services.GetRequiredService<IRepository<GmsMessage>>();
            var notifier = new Notifier(notifierlogger, notificationDb, messagesDb, hubContext);
            var notificationService = new NotificationService(notificationServiceLogger, notifier, notificationDb);
            notificationService.Start();
        }
    }
}

