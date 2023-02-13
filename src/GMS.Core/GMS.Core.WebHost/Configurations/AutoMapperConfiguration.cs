using AutoMapper;

namespace GMS.Core.WebHost.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper>(new Mapper(Configuration()));
        }
        private static MapperConfiguration Configuration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile<EntityNameCreateMappingsProfile>();
            });

            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}
