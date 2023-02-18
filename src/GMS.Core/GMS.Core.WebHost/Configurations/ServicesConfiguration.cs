using GMS.Core.BusinessLogic.Abstractions;
using GMS.Core.BusinessLogic.Services;

namespace GMS.Core.WebHost.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IFitnessClubService, FitnessClubService>()
                .AddTransient<IAreaService, AreaService>()
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IContractService, ContractService>()
                .AddTransient<ITimeSlotService, TimeSlotService>()
                .AddTransient<ITrainingService, TrainingService>();

            return serviceCollection;
        }
    }
}
