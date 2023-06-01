using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GMS.Core.Core.Domain.Employees;
using GMS.Core.DataAccess.Data;

namespace GMS.Core.DataAccess.Context.Configurations
{
    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.ToTable("Trainers");

            builder.HasMany(t => t.TimeSlots)
                   .WithOne(ts => ts.Trainer)
                   .HasForeignKey(ts => ts.TrainerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(SeedData.Trainers);
        }
    }
}
