using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace GMS.Core.WebHost.Configurations
{
    public static class LoggerConfiguration
    {
        public static IServiceCollection ConfigureLogger(this IServiceCollection serviceCollection)
        {
            // ToDo: перенести в настройки
            string UrlSeq = "http://localhost:5341";

            Log.Logger = new Serilog.LoggerConfiguration()
                .WriteTo.Console(new JsonFormatter())
                .WriteTo.Seq(UrlSeq)
                .CreateLogger();

            serviceCollection.AddSingleton(Log.Logger);

            return serviceCollection;
        }
    }
}
