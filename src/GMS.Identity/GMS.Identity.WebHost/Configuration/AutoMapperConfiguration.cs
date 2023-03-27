using AutoMapper;

namespace GMS.Identity.WebHost.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection ConfigureMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IMapper>(new Mapper(Configuration()));
            return serviceCollection;
        }

        private static MapperConfiguration Configuration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
                
            });

            //configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}
