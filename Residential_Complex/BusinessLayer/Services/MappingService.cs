using AutoMapper;
using AutoMapper.Features;
using ResidentialComplex.BusinessLayer.DomainModel;
using ResidentialComplex.DataAccessLayer;
using ResidentialComplex.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ResidentialComplex.BusinessLayer.Services
{
    public class MappingService
    {
        private IUnitOfWork unitOfWork;

        public MappingService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Owner Map(OwnerEntity ownerEntity)
        {
            return new Owner
            {
                Id = ownerEntity.ID,
                Name = ownerEntity.Name,
                PhoneNumber = ownerEntity.PhoneNumber,
                DateOfPurchase = ownerEntity.DateOfPurchase
            };
        }

        public OwnerEntity Map(Owner owner)
        {
            OwnerEntity ownerEntity = new OwnerEntity();
            if (owner.Id > 0)
            {
                ownerEntity = unitOfWork.FlatRepository.GetAll()
                    .Select(flatEntity => flatEntity.Owner)
                    .ToList()
                    .Find(own => own.ID == own.ID);
            }

            ownerEntity.ID = owner.Id;
            ownerEntity.Name = owner.Name;
            ownerEntity.PhoneNumber = owner.PhoneNumber;
            ownerEntity.DateOfPurchase = owner.DateOfPurchase;

            return ownerEntity;
        }

        public House Map(HouseEntity houseEntity)
        {
            return new House
            {
                Id = houseEntity.ID,
                NumberOfHouse = houseEntity.NumberOfHouse,
                Address = houseEntity.Address
            };
        }
        
        public HouseEntity Map(House house)
        {
            HouseEntity houseEntity;
            if (house.Id > 0)
                houseEntity = unitOfWork.HouseRepository.Read(house.Id);
            else
                houseEntity = new HouseEntity(); 

            houseEntity.ID = house.Id;
            houseEntity.NumberOfHouse = house.NumberOfHouse;
            houseEntity.Address = house.Address;

            return houseEntity;
        }

        public Flat Map(FlatEntity flatEntity)
        {
            return new Flat
            {
                Id = flatEntity.ID,
                Owner = Map(flatEntity.Owner),
                House = Map(flatEntity.House),
                ApartmentNumber = flatEntity.ApartmentNumber,
                Area = flatEntity.Area
            };
        }

        public FlatEntity Map(Flat flat)
        {
            FlatEntity flatEntity;
            if (flat.Id > 0)
                flatEntity = unitOfWork.FlatRepository.Read(flat.Id);
            else
                flatEntity = new FlatEntity();

            flatEntity.ID = flat.Id;
            flatEntity.Owner = Map(flat.Owner);
            flatEntity.House = Map(flat.House);
            flatEntity.ApartmentNumber = flat.ApartmentNumber;
            flatEntity.Area = flat.Area;

            return flatEntity;
        }

        public HousingDepartament Map(HousingDepartamentEntity housingDepartamentEntity)
        {
            return new HousingDepartament
            {
                Id = housingDepartamentEntity.ID,
                Name = housingDepartamentEntity.Name,
                Pay = housingDepartamentEntity.Pay,
                //Flat = housingDepartamentEntity.Flat
            };
        }

        public HousingDepartamentEntity Map(HousingDepartament housingDepartament)
        {
            HousingDepartamentEntity housingDepartamentEntity;
            if (housingDepartament.Id > 0)
                housingDepartamentEntity = unitOfWork.HousingDepartamentRepository.Read(housingDepartament.Id);
            else
                housingDepartamentEntity = new HousingDepartamentEntity();

            housingDepartamentEntity.ID = housingDepartament.Id;
            housingDepartamentEntity.Name = housingDepartament.Name;
            housingDepartamentEntity.Pay = housingDepartament.Pay;
            // housingDepartamentEntity.Flat = housingDepartament.Flat;

            return housingDepartamentEntity;
        }
    }
}
