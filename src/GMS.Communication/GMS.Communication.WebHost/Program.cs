using GMS.Communication.WebHost.Hubs;
using GMS.Communication.WebHost.Models;
using JWTAuthManager;
using Microsoft.AspNetCore.SignalR;

namespace GMS.Communication.WebHost
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureLogging((context, logging) =>
            {
                logging.AddConsole();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}

