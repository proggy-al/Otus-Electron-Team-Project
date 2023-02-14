using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GMS.Core.Core.Domain;

namespace GMS.Core.DataAccess.Context.Configurations
{
    public class TimeSlotConfiguration : IEntityTypeConfiguration<TimeSlot>
    {
        public void Configure(EntityTypeBuilder<TimeSlot> builder)
        {
            builder.HasOne(a => a.Training)
                   .WithOne(b => b.TimeSlot)
                   .HasForeignKey<Training>(b => b.TimeSlotId);

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
                   .HasColumnType("character varying(512)")
                   .IsUnicode(false);
            builder.Property(p => p.DateTime)
                   .IsRequired();
            builder.Property(p => p.Duration)
                   .IsRequired();
            builder.Property(p => p.TrainerId)
                   .IsRequired();
            builder.Property(p => p.AreaId)
                   .IsRequired();
            builder.Property(p => p.FitnessClubId)
                   .IsRequired();
            builder.HasIndex(p => p.DateTime)
                   .IsUnique();
        }
    }
}
