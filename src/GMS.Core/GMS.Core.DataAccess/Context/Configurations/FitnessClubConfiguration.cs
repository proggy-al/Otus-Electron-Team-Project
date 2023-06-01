using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Data;

namespace GMS.Core.DataAccess.Context.Configurations
{
    public class FitnessClubConfiguration : IEntityTypeConfiguration<FitnessClub>
    {
        public void Configure(EntityTypeBuilder<FitnessClub> builder)
        {
            builder.HasMany(f => f.Employees)
                   .WithOne(p => p.FitnessClub)
                   .HasForeignKey(a => a.FitnessClubId)
                   .IsRequired();
            builder.HasMany(f => f.Areas)
                   .WithOne(p => p.FitnessClub)
                   .HasForeignKey(a => a.FitnessClubId)
                   .IsRequired();
            builder.HasMany(f => f.Products)
                   .WithOne(p => p.FitnessClub)
                   .HasForeignKey(p => p.FitnessClubId)
                   .IsRequired();
            /*builder.HasMany(f => f.TimeSlots)
                   .WithOne(t => t.FitnessClub)
                   .HasForeignKey(t => t.FitnessClubId)
                   .IsRequired();*/

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
                   .HasColumnType("character varying(4096)")
                   .IsUnicode(false);
            builder.Property(p => p.Address)
                   .IsRequired(false)
                   .HasColumnType("character varying(256)")
                   .IsUnicode(false);
            builder.Property(p => p.OwnerId)
                   .IsRequired();
            builder.Property(p => p.IsDeleted)
                   .HasDefaultValue(false)
                   .IsRequired();

            builder.HasData(SeedData.FitnessClubs);
        }
    }
}
