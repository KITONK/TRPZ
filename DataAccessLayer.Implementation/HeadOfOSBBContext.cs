using Microsoft.EntityFrameworkCore;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
//using ResidentialComplex.Models;

namespace DataAccessLayer.Implementation
{
    public class HeadOfOSBBContext : DbContext
    {
        public DbSet<FlatEntity> Flats { get; set; }
        public DbSet<HouseEntity> Houses { get; set; }
        public DbSet<HousingDepartamentEntity> HousingDepartaments { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<HouseTypeEntity> HouseTypes { get; set; }

        public HeadOfOSBBContext() : base()
        { 
        }

        //конструктор с опциями DbContext, который использует базовый конструктор опции, для того,
        //чтобы мы могли передать эти опции и конкретную строку подключения
        public HeadOfOSBBContext(DbContextOptions<HeadOfOSBBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // For migrations only
            //string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=ResidentialComplex;Integrated Security=True";

            string connectionString = ConfigurationManager.ConnectionStrings["ResidentialComplexDatabase"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
            //base.OnModelCreating(modelBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    HouseTypeEntity houseType1 = new HouseTypeEntity
        //    {
        //        Id = 1,
        //        NumberOfHouse = 1
        //    };
        //    HouseTypeEntity houseType2 = new HouseTypeEntity
        //    {
        //        Id = 2,
        //        NumberOfHouse = 2
        //    };
        //    HouseTypeEntity houseType3 = new HouseTypeEntity
        //    {
        //        Id = 3,
        //        NumberOfHouse = 3
        //    };
        //    HouseTypeEntity houseType4 = new HouseTypeEntity
        //    {
        //        Id = 4,
        //        NumberOfHouse = 4
        //    };

        //    HouseEntity houseEntity1 = new HouseEntity
        //    {
        //        ID = 1,
        //        TypeId = 1,
        //        Address = "Soborna 2"
        //    };
        //    HouseEntity houseEntity2 = new HouseEntity
        //    {
        //        ID = 2,
        //        TypeId = 2,
        //        Address = "Soborna 2a"
        //    };
        //    HouseEntity houseEntity3 = new HouseEntity
        //    {
        //        ID = 3,
        //        TypeId = 3,
        //        Address = "Soborna 3"
        //    };
        //    HouseEntity houseEntity4 = new HouseEntity
        //    {
        //        ID = 4,
        //        TypeId = 4,
        //        Address = "Soborna 4"
        //    };

        //    OwnerEntity owner1 = new OwnerEntity
        //    {
        //        ID = 1,
        //        Name = "Aleks Skritskii",
        //        PhoneNumber = "12345",
        //        DateOfPurchase = Convert.ToDateTime("19/07/2019 10:00")
        //    };
        //    OwnerEntity owner2 = new OwnerEntity
        //    {
        //        ID = 2,
        //        Name = "LizaSimpson",
        //        PhoneNumber = "267891",
        //        DateOfPurchase = Convert.ToDateTime("03/08/2016 12:00")
        //    };
        //    OwnerEntity owner3 = new OwnerEntity
        //    {
        //        ID = 3,
        //        Name = "MaksBelii",
        //        PhoneNumber = "891903",
        //        DateOfPurchase = Convert.ToDateTime("30/10/2020 13:00")
        //    };
        //    OwnerEntity owner4 = new OwnerEntity
        //    {
        //        ID = 4,
        //        Name = "KyryloShchupii",
        //        PhoneNumber = "696969",
        //        DateOfPurchase = Convert.ToDateTime("06/09/2016 20:00")

        //    };
        //    OwnerEntity owner5 = new OwnerEntity
        //    {
        //        ID = 5,
        //        Name = "MariaTkach",
        //        PhoneNumber = "642781",
        //        DateOfPurchase = Convert.ToDateTime("12/02/2017 12:00")
        //    };
        //    OwnerEntity owner6 = new OwnerEntity
        //    {
        //        ID = 6,
        //        Name = "VitaliiKlimchenko",
        //        PhoneNumber = "327891",
        //        DateOfPurchase = Convert.ToDateTime("23/11/2018 15:00")
        //    };

        //    object flat1 = new { ID = 1, ApartmentNumber = 1, Area = 67.5F, OwnerId = 1, HouseId = 1 };
        //    object flat2 = new { ID = 2, ApartmentNumber = 3, Area = 59.7F, OwnerId = 2, HouseId = 1 };
        //    object flat3 = new { ID = 3, ApartmentNumber = 49, Area = 90.7F, OwnerId = 3, HouseId = 2 };
        //    object flat4 = new { ID = 4, ApartmentNumber = 69, Area = 69.6F, OwnerId = 4, HouseId = 2 };
        //    object flat5 = new { ID = 5, ApartmentNumber = 115, Area = 76.3F, OwnerId = 5, HouseId = 3 };
        //    object flat6 = new { ID = 6, ApartmentNumber = 121, Area = 81.2F, OwnerId = 6, HouseId = 4 };

        //    var houseTypes = new List<HouseTypeEntity>();
        //    houseTypes.Add(houseType1);
        //    houseTypes.Add(houseType2);
        //    houseTypes.Add(houseType3);
        //    houseTypes.Add(houseType4);

        //    var houses = new List<HouseEntity>();
        //    houses.Add(houseEntity1);
        //    houses.Add(houseEntity2);
        //    houses.Add(houseEntity3);
        //    houses.Add(houseEntity4);

        //    var owners = new List<OwnerEntity>();
        //    owners.Add(owner1);
        //    owners.Add(owner2);
        //    owners.Add(owner3);
        //    owners.Add(owner4);
        //    owners.Add(owner5);
        //    owners.Add(owner6);

        //    var flats = new List<object>();
        //    flats.Add(flat1);
        //    flats.Add(flat2);
        //    flats.Add(flat3);
        //    flats.Add(flat4);
        //    flats.Add(flat5);
        //    flats.Add(flat6);

        //    modelBuilder.Entity<HouseTypeEntity>().HasData(houseTypes);
        //    modelBuilder.Entity<HouseEntity>().HasData(houses);
        //    modelBuilder.Entity<OwnerEntity>().HasData(owners);
        //    modelBuilder.Entity<FlatEntity>().HasData(flats);
        //}

        //List<OwnerEntity> owner = new List<OwnerEntity>
        //{
        //    new OwnerEntity
        //    {
        //        ID = 1,
        //        Name = "AleksSkritskii",
        //        PhoneNumber = "12345",
        //        DateOfPurchase = Convert.ToDateTime("19/07/2019 10:00")
        //    },
        //    new OwnerEntity
        //    {
        //        ID = 2,
        //        Name = "LizaSimpson",
        //        PhoneNumber = "267891",
        //        DateOfPurchase = Convert.ToDateTime("03/08/2016 12:00")
        //    },
        //    new OwnerEntity
        //    {
        //        ID = 3,
        //        Name = "MaksBelii",
        //        PhoneNumber = "891903",
        //        DateOfPurchase = Convert.ToDateTime("30/10/2020 13:00")
        //    },
        //    new OwnerEntity
        //    {
        //        ID = 4,
        //        Name = "KyryloShchupii",
        //        PhoneNumber = "696969",
        //        DateOfPurchase = Convert.ToDateTime("06/09/2016 20:00")
        //    },
        //    new OwnerEntity
        //    {
        //        ID = 5,
        //        Name = "MariaTkach",
        //        PhoneNumber = "642781",
        //        DateOfPurchase = Convert.ToDateTime("12/02/2017 12:00")
        //    },
        //    new OwnerEntity
        //    {
        //        ID = 6,
        //        Name = "VitaliiKlimchenko",
        //        PhoneNumber = "327891",
        //        DateOfPurchase = Convert.ToDateTime("23/11/2018 15:00")
        //    }
        //};
        //modelBuilder.Entity<OwnerEntity>().HasData(owner);
        //modelBuilder.Entity<HouseEntity>().HasData(
        //    new HouseEntity
        //    {
        //        ID = 1,
        //        NumberOfHouse = 1,
        //        Address = "Soborna2",
        //        Flats = new Collection<FlatEntity>
        //        {
        //            new FlatEntity
        //            { ID = 1, Owner = owner.Find(own => own.ID == 1), Area = 67.5F, ApartmentNumber = 1 },
        //            new FlatEntity
        //            { ID = 2, Owner = owner.Find(own => own.ID == 2), Area = 59.7F, ApartmentNumber = 3 }
        //        }
        //    },
        //    new HouseEntity
        //    {
        //        ID = 2,
        //        NumberOfHouse = 2,
        //        Address = "Soborna2a",
        //        Flats = new Collection<FlatEntity>
        //        {
        //            new FlatEntity
        //            { ID = 3, Owner = owner.Find(own => own.ID == 3), Area = 90.7F, ApartmentNumber = 49 },
        //            new FlatEntity
        //            { ID = 4, Owner = owner.Find(own => own.ID == 4), Area = 69.6F, ApartmentNumber = 69 }
        //        }
        //    },
        //    new HouseEntity
        //    {
        //        ID = 3,
        //        NumberOfHouse = 3,
        //        Address = "Soborna3",
        //        Flats = new Collection<FlatEntity>
        //        {
        //            new FlatEntity
        //            { ID = 5, Owner = owner.Find(own => own.ID == 5), Area = 76.3F, ApartmentNumber = 115 }
        //        }
        //    },
        //    new HouseEntity
        //    {
        //        ID = 4,
        //        NumberOfHouse = 4,
        //        Address = "Soborna4",
        //        Flats = new Collection<FlatEntity>
        //        {
        //            new FlatEntity
        //            { ID = 6, Owner = owner.Find(own => own.ID == 6), Area = 81.2F, ApartmentNumber = 121 },
        //        }
        //    });
        //}
    }
}
