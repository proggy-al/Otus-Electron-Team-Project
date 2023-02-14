using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GMS.Core.DataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        // ToDo: перенести в настройки
        private readonly string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=GMS;";
        
        public DbSet<FitnessClub> FitnessClubs { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Training> Trainings { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ToDo: создать ограничения уникальности для всех сущностей

            base.OnModelCreating(modelBuilder);
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.ApplyConfiguration(new FitnessClubConfiguration());
            modelBuilder.ApplyConfiguration(new AreaConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ContractConfiguration());
            modelBuilder.ApplyConfiguration(new TimeSlotConfiguration());
            modelBuilder.ApplyConfiguration(new TrainingConfiguration());
        }
    }
}
