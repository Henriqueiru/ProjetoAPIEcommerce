﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniCommerce.Data.Database;

#nullable disable

namespace MiniCommerce.Migrations
{
  [DbContext(typeof(AppDbContext))]
  partial class AppDbContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

      modelBuilder.Entity("MiniCommerce.Domain.Entities.Category", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("INTEGER");

            b.Property<DateTime>("CreatedOn")
                      .HasColumnType("TEXT");

            b.Property<string>("Description")
                      .IsRequired()
                      .HasColumnType("TEXT");

            b.Property<string>("Name")
                      .IsRequired()
                      .HasColumnType("TEXT");

            b.Property<DateTime>("UpdatedOn")
                      .HasColumnType("TEXT");

            b.HasKey("Id");

            b.ToTable("Categories");
          });

      modelBuilder.Entity("MiniCommerce.Domain.Entities.Product", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("INTEGER");

            b.Property<int>("CategoryId")
                      .HasColumnType("INTEGER");

            b.Property<DateTime>("CreatedOn")
                      .HasColumnType("TEXT");

            b.Property<string>("Description")
                      .IsRequired()
                      .HasColumnType("TEXT");

            b.Property<decimal>("Price")
                      .IsRequired()
                      .HasColumnType("NUMERIC");

            b.Property<string>("Name")
                      .IsRequired()
                      .HasColumnType("TEXT");

            b.Property<DateTime>("UpdatedOn")
                      .HasColumnType("TEXT");

            b.HasKey("Id");

            b.HasIndex("CategoryId");

            b.ToTable("Products");
          });

      modelBuilder.Entity("MiniCommerce.Domain.Entities.Product", b =>
          {
            b.HasOne("MiniCommerce.Domain.Entities.Category", "Category")
                      .WithMany()
                      .HasForeignKey("CategoryId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("Category");
          });
#pragma warning restore 612, 618
    }
  }
}
