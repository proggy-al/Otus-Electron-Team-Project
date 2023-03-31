using AutoMapper;
using GMS.Core.BusinessLogic.Mappings;
using GMS.Core.WebHost.Mappings;

namespace GMS.Core.WebHost.Configurations
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
                cfg.AddProfile<FitnessClubMappingsProfile>();
                cfg.AddProfile<EmployeeMappingsProfile>();
                cfg.AddProfile<AreaMappingsProfile>();
                cfg.AddProfile<ProductMappingsProfile>();
                //cfg.AddProfile<ContractMappingsProfile>();
                //cfg.AddProfile<TimeSlotMappingsProfile>();
                //cfg.AddProfile<TrainingMappingsProfile>();

                cfg.AddProfile<FitnessClubVmMappingsProfile>();
                cfg.AddProfile<AreaVmMappingsProfile>();
                cfg.AddProfile<ProductVmMappingsProfile>();
                //cfg.AddProfile<ContractVmMappingsProfile>();
                //cfg.AddProfile<TimeSlotVmMappingsProfile>();
                //cfg.AddProfile<TrainingVmMappingsProfile>();
            });

            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}
