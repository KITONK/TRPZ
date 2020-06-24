using Microsoft.EntityFrameworkCore;
using ResidentialComplex.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using ResidentialComplex.BusinessLayer.DomainModel;

namespace ResidentialComplex.DataAccessLayer
{
    public class HeadOfOSBBContext : DbContext
    {
        public DbSet<FlatEntity> Flats { get; set; }
        public DbSet<HouseEntity> Houses { get; set; }
        public DbSet<HousingDepartamentEntity> HousingDepartaments { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }

        public HeadOfOSBBContext() : base()
        { 
        }
        public HeadOfOSBBContext(DbContextOptions<HeadOfOSBBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // For migrations only
            //string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=ResidentialComplex;Integrated Security=True";

            string connectionString = ConfigurationManager.ConnectionStrings["TariffsDatabase"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
            //base.OnModelCreating(modelBuilder);

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
        }
    }
}
