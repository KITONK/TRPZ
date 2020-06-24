using AutoMapper;
using ResidentialComplex.BusinessLayer.DomainModel;
using ResidentialComplex.BusinessLayer.Services;
using ResidentialComplex.DataAccessLayer;
using ResidentialComplex.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;


namespace ResidentialComplex.BusinessLayer.Services
{
    public class HousingDepartamentService : IHousingDepartamentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly MappingService mappingService;

        public HousingDepartamentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            mappingService = new MappingService(unitOfWork);
        }

        public IEnumerable<HousingDepartament> GetHousingDepartaments()
        {
            return unitOfWork.HousingDepartamentRepository.GetAll().Select(tariff => mapper.Map <HousingDepartament>(tariff));
        }

        public void SaveTariffs(IEnumerable<HousingDepartament> tariffs)
        {
            var _ = unitOfWork.HousingDepartamentRepository.GetAll();
            foreach(var tariff in tariffs)
            {
                if (tariff.Id > 0)
                    unitOfWork.HousingDepartamentRepository.Update(mappingService.Map(tariff));
                else
                    unitOfWork.HousingDepartamentRepository.Create(mappingService.Map(tariff));
            }

            unitOfWork.SaveChanges();
        }
    }
}
