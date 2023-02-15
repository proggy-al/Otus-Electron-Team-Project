using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GMS.Core.Core.Domain;

namespace GMS.Core.DataAccess.Context.Configurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.Property(p => p.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("uuid_generate_v4()")
                   .IsRequired();
            builder.Property(p => p.ProductId)
                   .IsRequired();
            builder.Property(p => p.ManagerId)
                   .IsRequired();
            builder.Property(p => p.UserId)
                   .IsRequired();
            builder.Property(p => p.FitnessClubId)
                   .IsRequired();
            builder.Property(p => p.StartDate)
                   .IsRequired();
            builder.Property(p => p.EndDate)
                   .IsRequired();

            // Gold's Gym Venice
            builder.HasData
            (
                new Contract
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000001"),
                    ProductId = Guid.Parse("b0000000-0000-0000-0000-000000000002"), // 12-Month Contract
                    ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000001"),
                    UserId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(365)
                },
                new Contract
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000002"),
                    ProductId = Guid.Parse("b0000000-0000-0000-0000-000000000003"), // 1 personal Training for a month
                    ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000001"),
                    UserId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(30)
                }
            ); ;

            // Алмаз
            builder.HasData
            (
                new Contract
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000003"),
                    ProductId = Guid.Parse("b0000000-0000-0000-0000-000000000006"), // Абонемент на месяц
                    ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000002"),
                    UserId = Guid.Parse("00000000-0000-0000-0001-000000000002"),
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000002"),
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(30)
                },
                new Contract
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000004"),
                    ProductId = Guid.Parse("b0000000-0000-0000-0000-000000000008"), // 8 персональных тренировок на месяц
                    ManagerId = Guid.Parse("00000000-0000-0000-0006-000000000002"),
                    UserId = Guid.Parse("00000000-0000-0000-0001-000000000002"),
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000002"),
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(30)
                }
            );
        }
    }
}
