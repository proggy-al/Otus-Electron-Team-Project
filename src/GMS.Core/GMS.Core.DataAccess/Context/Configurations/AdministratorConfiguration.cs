using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GMS.Core.Core.Domain;
using GMS.Core.Core.Domain.Employees;
using GMS.Core.DataAccess.Data;

namespace GMS.Core.DataAccess.Context.Configurations
{
    public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.ToTable("Administrators");

            builder.HasData(SeedData.Administrators);
        }
    }
}
