using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GMS.Core.Core.Domain;

namespace GMS.Core.DataAccess.Context.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(a => a.Contract)
                   .WithOne(b => b.Product)
                   .HasForeignKey<Contract>(b => b.ProductId);

            builder.Property(p => p.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("uuid_generate_v4()")
                   .IsRequired();
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasColumnType("character varying(64)")
                   .IsUnicode(false);
            builder.Property(p => p.Description)
                   .IsRequired(false)
                   .HasColumnType("character varying(1024)")
                   .IsUnicode(false);
            builder.Property(p => p.Quantity)
                   .IsRequired();
            builder.Property(p => p.Price)
                   .IsRequired();
            builder.Property(p => p.FitnessClubId)
                   .IsRequired();
            builder.Property(p => p.Deleted)
                   .HasDefaultValue(false);

            builder.HasIndex(p => new { p.Name, p.FitnessClubId })
                   .IsUnique();

            // Gold's Gym Venice
            builder.HasData
            (
                new Product
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000001"),
                    Name = "1-Month Contract",
                    Description = "Free access to the club for 30 days",
                    Quantity = 30,
                    Price = 100, // $
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001")
                },
                new Product
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000002"),
                    Name = "12-Month Contract",
                    Description = "Free access to the club for 1 year",
                    Quantity = 365,
                    Price = 490,  // $
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001")
                },
                new Product
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000003"),
                    Name = "1 personal Training",
                    Description = "for a month",
                    Quantity = 1,
                    Price = 65,   // $
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001")
                },
                new Product
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000004"),
                    Name = "8 personal Training",
                    Description = "for a month",
                    Quantity = 8,
                    Price = 360,   // $
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001")
                }
            );

            // Алмаз
            builder.HasData
            (
                new Product
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000005"),
                    Name = "Разовое посещение",
                    Description = "Свободное посещение клуба в течении 1 дня",
                    Quantity = 1,
                    Price = 500,    // рублей
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000002")
                },
                new Product
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000006"),
                    Name = "Абонемент на месяц",
                    Description = "Свободное посещение клуба в течении 30 дней",
                    Quantity = 30,
                    Price = 2000,   // рублей
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000002")
                },
                new Product
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000007"),
                    Name = "1 персональная тренировка",
                    Description = "на 1 месяц",
                    Quantity = 1,
                    Price = 2000,   // рублей
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000002")
                },
                new Product
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000008"),
                    Name = "8 персональных тренировок",
                    Description = "на 1 месяц",
                    Quantity = 8,
                    Price = 12000,  // рублей
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000002")
                }
            );
        }
    }
}
