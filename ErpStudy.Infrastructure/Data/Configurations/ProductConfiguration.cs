﻿using ErpStudy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpStudy.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR(250)")
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(p => p.SKUCode)
                .HasColumnName("SKUCode")
                .HasColumnType("NVARCHAR(12)");

            builder.Property(p => p.SalesPrice)
                .HasColumnName("SalesPrice")
                .HasColumnType("DECIMAL(18,2)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(p => p.Unity)
                .HasColumnName("Unity")
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(p => p.Condition)
                .HasColumnName("Condition")
                .HasColumnType("INT")
                .IsRequired();

            builder.HasIndex(p => p.SKUCode);
        }
    }
}