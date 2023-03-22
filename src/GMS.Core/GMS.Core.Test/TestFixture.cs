using Microsoft.Extensions.DependencyInjection;
using GMS.Core.WebHost.Configurations;
using GMS.Core.DataAccess.Context;
using AutoFixture;
using GMS.Core.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace GMS.Core.Test
{
    public class TestFixture : IDisposable
    {
        public IServiceProvider ServiceProvider { get; set; }

        public IServiceCollection ServiceCollection { get; set; }

        public TestFixture()
        {
            var services = new ServiceCollection();

            services.ConfigureMapper();

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase("GmsCore");
            });

            services.AddRepositories();
            ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Засею пока только Contracts
        /// </summary>
        void SeedDb()
        {
            using (var db = ServiceProvider.GetRequiredService<DatabaseContext>())
            {
                var created = db.Database.EnsureCreated();

                if (created)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        var fixture = new Fixture();
                        var newItem = fixture.Build<Contract>().Without(e => e.Product).Without(e => e.FitnessClub).Create();
                        db.Contracts.Add(newItem);
                    }
                    db.SaveChanges();
                }
            }
        }

        public void Dispose()
        {
        }
    }
}
