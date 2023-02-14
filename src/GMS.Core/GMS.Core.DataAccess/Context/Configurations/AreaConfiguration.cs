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

            builder.HasIndex(p => new { p.Name, p.FitnessClubId })
                   .IsUnique();
        }
    }
}
