using ErpStudy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpStudy.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.UserName)
                .HasColumnName("UserName")
                .HasColumnType("NVARCHAR(250)")
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(c => c.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("VARBINARY(MAX)")
                .IsRequired();

            builder.Property(c => c.PasswordSalt)
                .HasColumnName("PasswordSalt")
                .HasColumnType("VARBINARY(MAX)")
                .IsRequired();

            builder.HasIndex(c => c.UserName);
        }
    }
}