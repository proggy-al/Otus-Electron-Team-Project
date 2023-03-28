using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Data;

namespace GMS.Core.DataAccess.Context.Configurations
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasOne(a => a.TimeSlot)
                   .WithOne(t => t.Area)
                   .HasForeignKey<TimeSlot>(t => t.AreaId)
                   .IsRequired();

            builder.Property(a => a.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("uuid_generate_v4()")
                   .IsRequired();
            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasColumnType("character varying(64)")
                   .IsUnicode(false);
            builder.Property(a => a.FitnessClubId)
                   .IsRequired();
            builder.Property(a => a.IsDeleted)
                   .HasDefaultValue(false)
                   .IsRequired();

            builder.HasData(SeedData.Areas);
        }
    }
}
