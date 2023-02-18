using Serilog;

namespace GMS.Core.WebHost.Configurations
{
    public static class LoggerConfiguration
    {
        public static IServiceCollection ConfigureLogger(this IServiceCollection serviceCollection)
        {
            // ToDo: перенести в настройки
            string UrlSeq = "http://db_seq:5341";

            Log.Logger = new Serilog.LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.Seq(UrlSeq)
                .CreateLogger();

            serviceCollection.AddSingleton(Log.Logger);

            return serviceCollection;
        }
    }
}
