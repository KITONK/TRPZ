﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResidentialComplex.DataAccessLayer;

namespace ResidentialComplex.DataAccessLayer.Migrations
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

            modelBuilder.Entity("ResidentialComplex.DataAccessLayer.Entities.FlatEntity", b =>
            {
                b.Property<int>("ID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("ApartmentNumber")
                    .HasColumnType("int");

                b.Property<float>("Area")
                    .HasColumnType("real");

                b.Property<int>("HouseID")
                    .HasColumnType("int");

                b.Property<int>("OwnerID")
                    .HasColumnType("int");

                b.HasKey("ID");

                b.HasIndex("HouseID");

                b.HasIndex("OwnerID");

                b.ToTable("Flats");

                b.HasData(
                    new
                    {
                        Id = 1,
                        ApartmentNumber = 1,
                        Area = 67.5,
                        HouseId = 1,
                        OwnerId = 1
                    },
                    new
                    {
                        Id = 2,
                        ApartmentNumber = 3,
                        Area = 59.7,
                        HouseId = 1,
                        OwnerId = 2
                    },
                    new
                    {
                        Id = 3,
                        ApartmentNumber = 49,
                        Area = 90.7,
                        HouseId = 2,
                        OwnerId = 3
                    },
                    new
                    {
                        Id = 4,
                        ApartmentNumber = 69,
                        Area = 69.6,
                        HouseId = 2,
                        OwnerId = 4
                    },
                    new
                    {
                        Id = 5,
                        ApartmentNumber = 115,
                        Area = 76.3,
                        HouseId = 3,
                        OwnerId = 5
                    },
                    new
                    {
                        Id = 6,
                        ApartmentNumber = 121,
                        Area = 81.2,
                        HouseId = 4,
                        OwnerId = 6
                    }
                    );
            });

            modelBuilder.Entity("ResidentialComplex.DataAccessLayer.Entities.HouseEntity", b =>
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

                b.HasKey("ID");

                b.ToTable("Houses");

                b.HasData(
                    new
                    {
                        Id = 1,
                        NumberOfHouse = 1,
                        Address = "Soborna2"
                    },
                    new
                    {
                        Id = 2,
                        NumberOfHouse = 2,
                        Address = "Soborna2a"
                    },
                    new
                    {
                        Id = 3,
                        NumberOfHouse = 3,
                        Address = "Soborna3"
                    },
                    new
                    {
                        Id = 4,
                        NumberOfHouse = 4,
                        Address = "Soborna4"
                    }
                    );
            });

            modelBuilder.Entity("ResidentialComplex.DataAccessLayer.Entities.HousingDepartamentEntity", b =>
            {
                b.Property<int>("ID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("FlatID")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<double>("Pay")
                    .HasColumnType("float");

                b.HasKey("ID");

                b.HasIndex("FlatID");

                b.ToTable("HousingDepartaments");
            });

            modelBuilder.Entity("ResidentialComplex.DataAccessLayer.Entities.OwnerEntity", b =>
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
                        Id = 1,
                        Name = "AleksSkritskii",
                        PhoneNumber = 12345,
                        DateOfPurchase = "19/07/2019 10:00"
                    },
                    new
                    {
                        Id = 2,
                        Name = "LizaSimpson",
                        PhoneNumber = 267891,
                        DateOfPurchase = "03/08/2016 12:00"
                    },
                    new
                    {
                        Id = 3,
                        Name = "MaksBelii",
                        PhoneNumber = 891903,
                        DateOfPurchase = "30/10/2020 13:00"
                    },
                    new
                    {
                        Id = 4,
                        Name = "KyryloShchupii",
                        PhoneNumber = 696969,
                        DateOfPurchase = "06/09/2016 20:00"
                    },
                    new
                    {
                        Id = 5,
                        Name = "MariaTkach",
                        PhoneNumber = 642781,
                        DateOfPurchase = "12/02/2017 12:00"
                    },
                    new
                    {
                        Id = 6,
                        Name = "VitaliiKlimchenko",
                        PhoneNumber = 327891,
                        DateOfPurchase = "23/11/2018 15:00"
                    }
                    );
            });

            modelBuilder.Entity("ResidentialComplex.DataAccessLayer.Entities.FlatEntity", b =>
            {
                b.HasOne("ResidentialComplex.DataAccessLayer.Entities.HouseEntity", "House")
                    .WithMany()
                    .HasForeignKey("HouseID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("ResidentialComplex.DataAccessLayer.Entities.OwnerEntity", "Owner")
                    .WithMany()
                    .HasForeignKey("OwnerID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("ResidentialComplex.DataAccessLayer.Entities.HousingDepartamentEntity", b =>
            {
                b.HasOne("ResidentialComplex.DataAccessLayer.Entities.FlatEntity", "Flat")
                    .WithMany()
                    .HasForeignKey("FlatID")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}