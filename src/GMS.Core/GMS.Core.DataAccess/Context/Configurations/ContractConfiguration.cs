using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GMS.Core.Core.Domain;

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
                   .IsRequired();
            builder.Property(p => p.UserId)
                   .IsRequired();
            builder.Property(p => p.FitnessClubId)
                   .IsRequired();
            builder.Property(p => p.StartDate)
                   .IsRequired();
            builder.Property(p => p.EndDate)
                   .IsRequired();
        }
    }
}
