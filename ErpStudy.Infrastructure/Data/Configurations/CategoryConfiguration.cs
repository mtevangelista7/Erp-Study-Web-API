using ErpStudy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpStudy.Infrastructure.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(c => c.Id);

            builder.HasMany<Product>(e => e.Products)
                .WithOne()
                .HasForeignKey(e => e.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .HasColumnType("250")
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}