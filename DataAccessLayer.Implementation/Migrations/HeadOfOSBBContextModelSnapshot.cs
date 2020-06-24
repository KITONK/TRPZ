﻿// <auto-generated />
using System;
using DataAccessLayer.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Implementation.Migrations
{
    [DbContext(typeof(HeadOfOSBBContext))]
    partial class HeadOfOSBBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.FlatEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApartmentNumber")
                        .HasColumnType("int");

                    b.Property<float>("Area")
                        .HasColumnType("real");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("HouseId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Flats");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ApartmentNumber = 1,
                            Area = 67.5f,
                            HouseId = 1,
                            OwnerId = 1
                        },
                        new
                        {
                            ID = 2,
                            ApartmentNumber = 3,
                            Area = 59.7f,
                            HouseId = 1,
                            OwnerId = 2
                        },
                        new
                        {
                            ID = 3,
                            ApartmentNumber = 49,
                            Area = 90.7f,
                            HouseId = 2,
                            OwnerId = 3
                        },
                        new
                        {
                            ID = 4,
                            ApartmentNumber = 69,
                            Area = 69.6f,
                            HouseId = 2,
                            OwnerId = 4
                        },
                        new
                        {
                            ID = 5,
                            ApartmentNumber = 115,
                            Area = 76.3f,
                            HouseId = 3,
                            OwnerId = 5
                        },
                        new
                        {
                            ID = 6,
                            ApartmentNumber = 121,
                            Area = 81.2f,
                            HouseId = 4,
                            OwnerId = 6
                        });
                });

            modelBuilder.Entity("Entities.HouseEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfHouse")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TypeId");

                    b.ToTable("Houses");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "Soborna 2",
                            NumberOfHouse = 0,
                            TypeId = 1
                        },
                        new
                        {
                            ID = 2,
                            Address = "Soborna 2a",
                            NumberOfHouse = 0,
                            TypeId = 2
                        },
                        new
                        {
                            ID = 3,
                            Address = "Soborna 3",
                            NumberOfHouse = 0,
                            TypeId = 3
                        },
                        new
                        {
                            ID = 4,
                            Address = "Soborna 4",
                            NumberOfHouse = 0,
                            TypeId = 4
                        });
                });

            modelBuilder.Entity("Entities.HouseTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumberOfHouse")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HouseTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NumberOfHouse = 1
                        },
                        new
                        {
                            Id = 2,
                            NumberOfHouse = 2
                        },
                        new
                        {
                            Id = 3,
                            NumberOfHouse = 3
                        },
                        new
                        {
                            Id = 4,
                            NumberOfHouse = 4
                        });
                });

            modelBuilder.Entity("Entities.HousingDepartamentEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlatId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Pay")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("FlatId");

                    b.ToTable("HousingDepartaments");
                });

            modelBuilder.Entity("Entities.OwnerEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfPurchase")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DateOfPurchase = new DateTime(2019, 7, 19, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Aleks Skritskii",
                            PhoneNumber = "12345"
                        },
                        new
                        {
                            ID = 2,
                            DateOfPurchase = new DateTime(2016, 8, 3, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "LizaSimpson",
                            PhoneNumber = "267891"
                        },
                        new
                        {
                            ID = 3,
                            DateOfPurchase = new DateTime(2020, 10, 30, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "MaksBelii",
                            PhoneNumber = "891903"
                        },
                        new
                        {
                            ID = 4,
                            DateOfPurchase = new DateTime(2016, 9, 6, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "KyryloShchupii",
                            PhoneNumber = "696969"
                        },
                        new
                        {
                            ID = 5,
                            DateOfPurchase = new DateTime(2017, 2, 12, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "MariaTkach",
                            PhoneNumber = "642781"
                        },
                        new
                        {
                            ID = 6,
                            DateOfPurchase = new DateTime(2018, 11, 23, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "VitaliiKlimchenko",
                            PhoneNumber = "327891"
                        });
                });

            modelBuilder.Entity("Entities.FlatEntity", b =>
                {
                    b.HasOne("Entities.HouseEntity", "House")
                        .WithMany()
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.OwnerEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.HouseEntity", b =>
                {
                    b.HasOne("Entities.HouseTypeEntity", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.HousingDepartamentEntity", b =>
                {
                    b.HasOne("Entities.FlatEntity", "Flat")
                        .WithMany()
                        .HasForeignKey("FlatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}