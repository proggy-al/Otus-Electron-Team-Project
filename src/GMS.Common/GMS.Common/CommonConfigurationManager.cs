using Microsoft.Extensions.Configuration;

namespace GMS.Common
{
    public static class CommonConfigurationManager
    {
        public static readonly IConfigurationRoot Configuration;

        static CommonConfigurationManager()
        {
            Configuration = new ConfigurationBuilder().AddJsonFile("commonsettings.json").Build();
        }
    }
}
