using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GMS.Core.Core.Domain;

namespace GMS.Core.DataAccess.Context.Configurations
{
    public class FitnessClubConfiguration : IEntityTypeConfiguration<FitnessClub>
    {
        public void Configure(EntityTypeBuilder<FitnessClub> builder)
        {
            builder.HasMany(f => f.Products)
                   .WithOne(p => p.FitnessClub)
                   .IsRequired();
            builder.HasMany(f => f.Areas)
                   .WithOne(p => p.FitnessClub)
                   .IsRequired();
            builder.HasMany(f => f.Contracts)
                   .WithOne(p => p.FitnessClub)
                   .IsRequired();
            builder.HasMany(f => f.TimeSlots)
                   .WithOne(p => p.FitnessClub)
                   .IsRequired();

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
            builder.HasIndex(p => p.Name)
                   .IsUnique();
        }
    }
}
