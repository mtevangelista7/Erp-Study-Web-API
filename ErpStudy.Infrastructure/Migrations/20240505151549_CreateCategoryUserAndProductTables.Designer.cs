﻿// <auto-generated />
using System;
using ErpStudy.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ErpStudy.Infrastructure.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20240505151549_CreateCategoryUserAndProductTables")]
    partial class CreateCategoryUserAndProductTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ErpStudy.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR(250)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("ErpStudy.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Condition")
                        .HasColumnType("INT")
                        .HasColumnName("Condition");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR(250)")
                        .HasColumnName("Name");

                    b.Property<string>("SKUCode")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(12)")
                        .HasColumnName("SKUCode");

                    b.Property<decimal>("SalesPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(18,2)")
                        .HasDefaultValue(0m)
                        .HasColumnName("SalesPrice");

                    b.Property<int>("Unity")
                        .HasColumnType("INT")
                        .HasColumnName("Unity");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SKUCode");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("ErpStudy.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("VARBINARY(MAX)")
                        .HasColumnName("PasswordSalt");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR(250)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.HasIndex("UserName");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ErpStudy.Domain.Entities.Product", b =>
                {
                    b.HasOne("ErpStudy.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ErpStudy.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
