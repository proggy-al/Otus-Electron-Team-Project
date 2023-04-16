using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GMS.Core.Core.Domain.Employees;
using GMS.Core.DataAccess.Data;

namespace GMS.Core.DataAccess.Context.Configurations
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.ToTable("Managers");

            builder.HasMany(m => m.Contracts)
                   .WithOne(c => c.Manager)
                   .HasForeignKey(c => c.ManagerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(SeedData.Managers);
        }
    }
}
