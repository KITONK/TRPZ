using AutoMapper;
using ResidentialComplex.BusinessLayer.DomainModel;
using ResidentialComplex.BusinessLayer.Services;
using ResidentialComplex.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using ResidentialComplex.DataAccessLayer;

namespace ResidentialComplex.BusinessLayer.Services
{
    public class FlatService : IFlatService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly MappingService mappingService;

        public FlatService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            mappingService = new MappingService(unitOfWork);
        }

        public IEnumerable<Flat> GetFlats(int numberOfHouse)
        {
            var flatEntities = unitOfWork.FlatRepository.GetAll();
            var list = new List<FlatEntity>(flatEntities);
            var flats = flatEntities.Select(flatEntity => mappingService.Map(flatEntity));
            var list2 = new List<Flat>(flats);
            return flats.Where(flat => flat.House.NumberOfHouse == numberOfHouse);
        }


    }
}
