﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(WatchShopDbContext))]
    partial class WatchShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data.Models.ClockFace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClockFace", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Blue"
                        },
                        new
                        {
                            Id = 2,
                            Name = "White"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Black"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Green"
                        });
                });

            modelBuilder.Entity("Data.Models.Watch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ClockFaceId")
                        .HasColumnType("int");

                    b.Property<string>("Guarantee")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("img")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ClockFaceId");

                    b.ToTable("Watches", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Rolex",
                            ClockFaceId = 3,
                            Guarantee = "3 years",
                            Material = "Steel 904L",
                            Model = "Air-King",
                            Price = 7400m,
                            img = "/Images/Rolex Air-King.png"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Rolex",
                            ClockFaceId = 3,
                            Guarantee = "3 years",
                            Material = "Stainless Steel",
                            Model = "Datejust",
                            Price = 7800m,
                            img = "/Images/Rolex Datejust.png"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Rolex",
                            ClockFaceId = 3,
                            Guarantee = "4 years",
                            Material = "18-carat Everose gold",
                            Model = "Yacht-Master",
                            Price = 47150m,
                            img = "/Images/Rolex Yacht-Master.png"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Rolex",
                            ClockFaceId = 2,
                            Guarantee = "5 years",
                            Material = "Stainless Steel, Yellow Gold 18k",
                            Model = "Sea-Dweller",
                            Price = 23500m,
                            img = "/Images/Rolex Sea-Dweller.png"
                        });
                });

            modelBuilder.Entity("Data.Models.Watch", b =>
                {
                    b.HasOne("Data.Models.ClockFace", "ClockFace")
                        .WithMany("Watches")
                        .HasForeignKey("ClockFaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClockFace");
                });

            modelBuilder.Entity("Data.Models.ClockFace", b =>
                {
                    b.Navigation("Watches");
                });
#pragma warning restore 612, 618
        }
    }
}
