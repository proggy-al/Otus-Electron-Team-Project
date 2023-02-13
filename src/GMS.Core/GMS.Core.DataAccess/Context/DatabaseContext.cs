using GMS.Core.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

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
            Database.EnsureCreated();
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

            modelBuilder.Entity<FitnessClub>()
                .Property(p => p.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsRequired();
            modelBuilder.Entity<FitnessClub>()
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnType("character varying(64)")
                .IsUnicode(false);
            modelBuilder.Entity<FitnessClub>()
                .Property(p => p.Description)
                .IsRequired(false)
                .HasColumnType("character varying(4096)")
                .IsUnicode(false);
            modelBuilder.Entity<FitnessClub>()
                .Property(p => p.Address)
                .IsRequired(false)
                .HasColumnType("character varying(256)")
                .IsUnicode(false);
            modelBuilder.Entity<FitnessClub>()
                .Property(p => p.OwnerId)
                .IsRequired();
            modelBuilder.Entity<FitnessClub>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Area>()
                 .Property(p => p.Id)
                 .HasColumnType("uuid")
                 .HasDefaultValueSql("uuid_generate_v4()")
                 .IsRequired();
            modelBuilder.Entity<Area>()
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnType("character varying(64)")
                .IsUnicode(false);
            modelBuilder.Entity<Area>()
                 .Property(p => p.FitnessClubId)
                 .IsRequired();
            modelBuilder.Entity<Area>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Product>()
               .Property(p => p.Id)
               .HasColumnType("uuid")
               .HasDefaultValueSql("uuid_generate_v4()")
               .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnType("character varying(64)")
                .IsUnicode(false); 
            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .IsRequired(false)
                .HasColumnType("character varying(1024)")
                .IsUnicode(false);
            modelBuilder.Entity<Product>()
                .Property(p => p.Quantity)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(p => p.FitnessClubId)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Contract>()
                .Property(p => p.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsRequired();
            modelBuilder.Entity<Contract>()
            .Property(p => p.ProductId)
                .IsRequired();
            modelBuilder.Entity<Contract>()
            .Property(p => p.ManagerId)
                .IsRequired();
            modelBuilder.Entity<Contract>()
                .Property(p => p.UserId)
                .IsRequired();
            modelBuilder.Entity<Contract>()
                .Property(p => p.FitnessClubId)
                .IsRequired();
            modelBuilder.Entity<Contract>()
                .Property(p => p.StartDate)
                .IsRequired();
            modelBuilder.Entity<Contract>()
                .Property(p => p.EndDate)
                .IsRequired();

            modelBuilder.Entity<TimeSlot>()
                 .Property(p => p.Id)
                 .HasColumnType("uuid")
                 .HasDefaultValueSql("uuid_generate_v4()")
                 .IsRequired();
            modelBuilder.Entity<TimeSlot>()
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnType("character varying(64)")
                .IsUnicode(false);
            modelBuilder.Entity<TimeSlot>()
                .Property(p => p.Description)
                .IsRequired(false)
                .HasColumnType("character varying(512)")
                .IsUnicode(false);
            modelBuilder.Entity<TimeSlot>()
                 .Property(p => p.DateTime)
                 .IsRequired();
            modelBuilder.Entity<TimeSlot>()
                 .Property(p => p.Duration)
                 .IsRequired();
            modelBuilder.Entity<TimeSlot>()
                 .Property(p => p.TrainerId)
                 .IsRequired();
            modelBuilder.Entity<TimeSlot>()
                 .Property(p => p.AreaId)
                 .IsRequired();
            modelBuilder.Entity<TimeSlot>()
                 .Property(p => p.FitnessClubId)
                 .IsRequired();
            modelBuilder.Entity<TimeSlot>()
                .HasIndex(p => p.DateTime)
                .IsUnique();

            modelBuilder.Entity<Training>()
                 .Property(p => p.Id)
                 .HasColumnType("uuid")
                 .HasDefaultValueSql("uuid_generate_v4()")
                 .IsRequired();
            modelBuilder.Entity<Training>()
                 .Property(p => p.UserId)
                 .IsRequired();
            modelBuilder.Entity<Training>()
                .Property(p => p.Description)
                .IsRequired(false)
                .HasColumnType("character varying(256)")
                .IsUnicode(false);
            modelBuilder.Entity<Training>()
                 .Property(p => p.TimeSlotId)
                 .IsRequired();
            modelBuilder.Entity<Training>()
                 .Property(p => p.Points)
                 .IsRequired(false);
        }
    }
}
