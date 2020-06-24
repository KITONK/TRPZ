using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ResidentialComplex.BusinessLayer.DomainModel;
using ResidentialComplex.BusinessLayer.Services;
using ResidentialComplex.DataAccessLayer;
using ResidentialComplex.DataAccessLayer.Entities;

namespace ResidentialComplex.BusinessLayer.Services
{
    public class HouseService : IHouseService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly MappingService mappingService;

        public HouseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            mappingService = new MappingService(unitOfWork);
        }

        public IEnumerable<int> GetNumberOfHouse()
        {
            IEnumerable<House> house = unitOfWork.HouseRepository.GetAll().Select(houseEntity => mappingService.Map(houseEntity));
            return house.Select(h => h.NumberOfHouse).ToHashSet();
        }
    }
}