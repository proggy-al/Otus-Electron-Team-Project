using GMS.Core.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GMS.Core.WebHost.Configurations
{
    public static class DBContextConfiguration
    {
        public static IServiceCollection AddDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(option =>
            {
                var connectionString = configuration.GetValue<string>("DBConnectionStrings");
                if (connectionString.IsNullOrEmpty())
                    throw new Exception("Connection string does not exist");
                option.UseNpgsql(connectionString);
            });
            return services;
        }
    }
}
