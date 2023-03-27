using Microsoft.AspNetCore.Mvc.Formatters;
using Serilog;
using System.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace GMS.Core.WebHost.BackgroundServices
{
    public class RefreshConfigurations : BackgroundService
    {
        private readonly IServiceProvider _services;
        public RefreshConfigurations(IServiceProvider services)
        {
            _services = services;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var scope = _services.CreateScope();
                var conf = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                var existSettings = conf.GetRequiredSection(nameof(RefreshSettings)).Get<RefreshSettings>();

                if (existSettings == null)
                {
                    throw new InvalidOperationException("Exists refresh configuration settings not found");
                }

                ConfigurationManager.RefreshSection(nameof(RefreshSettings));

                var newSettings = conf.GetRequiredSection(nameof(RefreshSettings)).Get<RefreshSettings>();

                if (newSettings == null)
                {
                    throw new InvalidOperationException("New refresh configuration settings not found");
                }

                if (!existSettings.IntervalRefresh.Equals(newSettings.IntervalRefresh))
                {
                    Log.Logger.Information("Changed refresh configuration interval");
                }

                await Task.Delay(newSettings.IntervalRefresh, stoppingToken);
            }
        }
    }
}
