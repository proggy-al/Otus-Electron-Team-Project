﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GMS.Core.Core.Domain;
using GMS.Core.DataAccess.Data;

namespace GMS.Core.DataAccess.Context.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(p => p.Contracts)
                   .WithOne(c => c.Product)
                   .HasForeignKey(c => c.ProductId)
                   .OnDelete(DeleteBehavior.SetNull);

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
                   .HasColumnType("character varying(1024)")
                   .IsUnicode(false);
            builder.Property(p => p.Quantity)
                   .IsRequired();
            builder.Property(p => p.Price)
                   .IsRequired();
            builder.Property(p => p.FitnessClubId)
                   .IsRequired();
            builder.Property(p => p.IsDeleted)
                   .HasDefaultValue(false)
                   .IsRequired();

            builder.HasData(SeedData.Products);
        }
    }
}
