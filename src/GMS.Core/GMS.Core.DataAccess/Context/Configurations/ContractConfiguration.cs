using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Data;

namespace GMS.Core.DataAccess.Context.Configurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {           
            builder.Property(p => p.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("uuid_generate_v4()")
                   .IsRequired();
            builder.Property(p => p.ProductId)
                   .IsRequired();
            builder.Property(p => p.ManagerId)
                   .IsRequired(false);
            builder.Property(p => p.UserId)
                   .IsRequired();
            builder.Property(p => p.StartDate)
                   .IsRequired();
            builder.Property(p => p.EndDate)
                   .IsRequired();
            builder.Property(p => p.IsApproved)
                   .HasDefaultValue(false)
                   .IsRequired(false);
            builder.Property(p => p.IsDeleted)
                   .HasDefaultValue(false)
                   .IsRequired();

            builder.HasData(SeedData.Contracts);
        }
    }
}
