using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GMS.Core.Core.Domain;

namespace GMS.Core.DataAccess.Context.Configurations
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasOne(a => a.TimeSlot)
                   .WithOne(b => b.Area)
                   .HasForeignKey<TimeSlot>(b => b.AreaId);

            builder.Property(p => p.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("uuid_generate_v4()")
                   .IsRequired();
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasColumnType("character varying(64)")
                   .IsUnicode(false);
            builder.Property(p => p.FitnessClubId)
                   .IsRequired();
            builder.Property(p => p.Deleted)
                   .HasDefaultValue(false);

            /*builder.HasIndex(p => new { p.Name, p.FitnessClubId})
                   .IsUnique();*/

            // Gold's Gym Venice
            builder.HasData
            (
                new Area
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000001"),
                    Name = "Outdoor workout area",
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                    Deleted = false
                },
                new Area
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000002"),
                    Name = "Free weights area",
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                    Deleted = false
                },
                new Area
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000003"),
                    Name = "Functional training area",
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                    Deleted = false
                },
                new Area
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000004"),
                    Name = "Resistance Machines area",
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                    Deleted = false
                },
                new Area
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000005"),
                    Name = "Cardio Equipment area",
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                    Deleted = false
                }
            );

            // Алмаз
            builder.HasData
            (
                new Area
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000006"),
                    Name = "Тренажерный зал",
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000002"),
                    Deleted = false
                },
                new Area
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000007"),
                    Name = "Зона кардиотренажеров",
                    FitnessClubId = Guid.Parse("f0000000-0000-0000-0000-000000000002"),
                    Deleted = false
                }
            );
        }
    }
}
