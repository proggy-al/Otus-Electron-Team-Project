using GMS.Core.Core.Abstractions.Repositories;
using GMS.Core.DataAccess.Repositories;

namespace GMS.Core.WebHost.Configurations
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IFitnessClubRepository, FitnessClubRepository>()
                .AddTransient<IEmployeeRepository, EmployeeRepository>()
                .AddTransient<ITrainerRepository, TrainerRepository>()
                .AddTransient<IManagerRepository, ManagerRepository>()
                .AddTransient<IAreaRepository, AreaRepository>()
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IContractRepository, ContractRepository>()
                .AddTransient<ITimeSlotRepository, TimeSlotRepository>()
                .AddTransient<ITrainingRepository, TrainingRepository>();
            return serviceCollection;
        }
    }
}
