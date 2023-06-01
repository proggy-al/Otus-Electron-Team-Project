using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Data;

namespace GMS.Core.DataAccess.Context.Configurations
{
    public class TrainingConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.Property(p => p.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("uuid_generate_v4()")
                   .IsRequired();
            builder.Property(p => p.UserId)
                   .IsRequired();
            builder.Property(p => p.TimeSlotId)
                   .IsRequired();
            builder.Property(p => p.TrainerNotes)
                   .HasColumnType("character varying(256)")
                   .IsUnicode(false)
                   .HasDefaultValue("")
                   .IsRequired();
            builder.Property(p => p.Points)
                   .HasDefaultValue(0)
                   .IsRequired();
            builder.Property(p => p.IsDeleted)
                   .HasDefaultValue(false)
                   .IsRequired();

            builder.HasData(SeedData.Trainings);
        }
    }
}
