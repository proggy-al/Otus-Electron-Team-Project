using GMS.Communication.DataAccess.Context;
using GMS.Communication.DataAccess.Data;

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
    }
}

