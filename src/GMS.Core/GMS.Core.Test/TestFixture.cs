using AutoFixture;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Context;
using GMS.Core.WebHost.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GMS.Core.Test
{
    public class TestFixture //: IDisposable
    {
        public IServiceProvider ServiceProvider { get; set; }

        private readonly DatabaseContext _db;

        public TestFixture()
        {

            var services = new ServiceCollection();

            services.ConfigureMapper();

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase("GmsCore");
            });

            //services.AddTransient<DbContext, DatabaseContext>();

            services.AddRepositories();

            var serviceProvider = services.BuildServiceProvider();
            ServiceProvider = serviceProvider;

            _db = ServiceProvider.GetRequiredService<DatabaseContext>();

            SeedDb();
        }

        /// <summary>
        /// Засею пока только Contracts
        /// </summary>
        private void SeedDb()
        {


            var created = _db.Database.EnsureCreated();

            if (created)
            {
                for (int i = 0; i < 20; i++)
                {
                    var fixture = new Fixture();
                    var newItem = fixture.Build<Contract>().Without(e => e.Product).Create();
                    _db.Contracts.Add(newItem);
                }
                _db.SaveChanges();
            }

        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
