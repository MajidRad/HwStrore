﻿// <auto-generated />
using System;
using HwStore.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HwStore.Persistence.Migrations
{
    [DbContext(typeof(HwStoreDbContext))]
    partial class HwStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HwStore.Domain.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Amd"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Intel"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Nvidia"
                        },
                        new
                        {
                            Id = 4,
                            Name = "CorsAir"
                        });
                });

            modelBuilder.Entity("HwStore.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cpu",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ram",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Vga",
                            ParentCategoryId = 1
                        });
                });

            modelBuilder.Entity("HwStore.Domain.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId1")
                        .HasColumnType("int");

                    b.Property<string>("PropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId1");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("HwStore.Domain.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("HwStore.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DetailId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CategoryId = 3,
                            Description = "Get the ultimate game changer. AMD Radeon™ RX 6800 XT graphics card features breakthrough AMD RDNA™ 2 architecture. ",
                            DetailId = 0,
                            Name = "6800XT",
                            Price = 800m,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            CategoryId = 3,
                            Description = "Get the ultimate game changer. AMD Radeon™ RX 6700 XT graphics card features breakthrough AMD RDNA™ 2 architecture. ",
                            DetailId = 0,
                            Name = "6700XT",
                            Price = 700m,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 3,
                            CategoryId = 3,
                            Description = "The GeForce RTX™ 3070 is powered by Ampere—NVIDIA's 2nd gen RTX architecture.",
                            DetailId = 0,
                            Name = "RTX 3070",
                            Price = 850m,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 2,
                            CategoryId = 1,
                            Description = "AMD Ryzen 7 5800X - Ryzen 7 5000 Series Vermeer (Zen 3) 8-Core 3.8 GHz Socket AM4 105W Desktop Processor ",
                            DetailId = 0,
                            Name = "Ryzen 7 5800X",
                            Price = 500m,
                            Quantity = 4
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 1,
                            CategoryId = 1,
                            Description = "AMD Ryzen 7 5700X - Ryzen 7 5000 Series Vermeer (Zen 3) 8-Core 3.4 GHz Socket AM4 105W Desktop Processor -",
                            DetailId = 0,
                            Name = "Ryzen 7 5700X",
                            Price = 400m,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 6,
                            BrandId = 2,
                            CategoryId = 1,
                            Description = "Intel Core i7-12700K - Core i7 12th Gen Alder Lake 12-Core (8P+4E) 3.6 GHz LGA 1700 125W Intel UHD Graphics 770",
                            DetailId = 0,
                            Name = "12700K",
                            Price = 450m,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 7,
                            BrandId = 2,
                            CategoryId = 1,
                            Description = "Intel Core i9-11900K - Core i9 11th Gen Rocket Lake 8-Core 3.5 GHz LGA 1200 125W Intel UHD Graphics 750 Desktop Processor ",
                            DetailId = 0,
                            Name = "11900K",
                            Price = 450m,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 8,
                            BrandId = 4,
                            CategoryId = 2,
                            Description = "Vengeance RGB Pro 16GB (2 x 8GB) Timing: 16-18-18-36  ",
                            DetailId = 0,
                            Name = "Vengeance RGB Pro",
                            Price = 100m,
                            Quantity = 10
                        });
                });

            modelBuilder.Entity("HwStore.Domain.Detail", b =>
                {
                    b.HasOne("HwStore.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId1");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("HwStore.Domain.Image", b =>
                {
                    b.HasOne("HwStore.Domain.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("HwStore.Domain.Product", b =>
                {
                    b.HasOne("HwStore.Domain.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HwStore.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("HwStore.Domain.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("HwStore.Domain.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("HwStore.Domain.Product", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}