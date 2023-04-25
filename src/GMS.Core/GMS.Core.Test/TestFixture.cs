using AutoFixture;
using GMS.Core.Core.Domain;
using GMS.Core.Core.Domain.Employees;
using GMS.Core.DataAccess.Context;
using GMS.Core.WebHost.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GMS.Core.Test
{
    [CollectionDefinition("ContractTests")]
    public class ContractTests : ICollectionFixture<TestFixture>  { }

    public class TestFixture : IDisposable
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public FitnessClub FitnessClub { get; private set; }
        public Manager Manager { get; private set; }
        public List<Contract> Contracts { get; private set; }

        private Fixture _fixture;
        private readonly DatabaseContext _dbContext;

        public TestFixture()
        {
            ServiceProvider = Services.BuildServiceProvider();
            _dbContext = ServiceProvider.GetRequiredService<DatabaseContext>();

            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(t => _fixture.Behaviors.Remove(t));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            SeedDataBase();
        }

        private IServiceCollection Services => new ServiceCollection()
            .AddAutoMapper()
            .AddDbContext<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase("GmsCore");
            })
            .AddRepositories();

        private void SeedDataBase()
        {
            FitnessClub = _fixture.Build<FitnessClub>()
                .With(f => f.IsDeleted, false)
                .With(f => f.Areas, new List<Area>())
                .With(f => f.Employees, new List<Employee>())
                .With(f => f.Products, new List<Product>())
                .Create();

            var _product = _fixture.Build<Product>()
                .With(f => f.IsDeleted, false)
                .With(p => p.FitnessClub, FitnessClub)
                .With(p => p.Contracts, new List<Contract>())
                .Create();

            Manager = _fixture.Build<Manager>()
                .With(f => f.IsDeleted, false)
                .With(x => x.FitnessClubId, FitnessClub.Id)
                .With(x => x.FitnessClub, FitnessClub)
                .With(p => p.Contracts, new List<Contract>())
                .Create();

            var _startDate = new DateTime(2023, 10, 10).ToUniversalTime();
            var _endDate = _startDate.AddYears(1);
            for (int i = 0; i < 30; i++)
            {
                var contract = _fixture.Build<Contract>()
                    .With(f => f.IsDeleted, false)
                    .With(e => e.Product, _product)
                    .With(c => c.Manager, Manager)
                    .With(e => e.StartDate, _startDate)
                    .With(e => e.EndDate, _endDate)
                    .With(e => e.IsApproved, (i % 2 == 0) ? true : false)
                    .Create();

                _product.Contracts.Add(contract);
            }

            Contracts = _product.Contracts.ToList();

            FitnessClub.Products.Add(_product);
            FitnessClub.Employees.Add(Manager);

            _dbContext.FitnessClubs.Add(FitnessClub);
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
