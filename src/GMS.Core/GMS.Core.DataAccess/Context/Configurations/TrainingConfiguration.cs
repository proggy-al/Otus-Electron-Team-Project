using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GMS.Core.Core.Domain;

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
            builder.Property(p => p.Description)
                   .HasColumnType("character varying(256)")
                   .IsUnicode(false)
                   .IsRequired(false);
            builder.Property(p => p.Points)
                   .IsRequired(false);
            builder.Property(p => p.IsDeleted)
                   .HasDefaultValue(false)
                   .IsRequired();
        }
    }
}
