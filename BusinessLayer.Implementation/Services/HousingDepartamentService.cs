using AutoMapper;
using Models;
using DataAccessLayer;
using Entities;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;


namespace BusinessLayer.Implementation.Services
{
    public class HousingDepartamentService : IHousingDepartamentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public HousingDepartamentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<HousingDepartament> GetHousingDepartaments()
        {
            return unitOfWork.HousingDepartamentRepository.GetAll().Select(tariff => mapper.Map <HousingDepartament>(tariff));
        }

        public void SaveTariff(HousingDepartament tariff)
        {
            unitOfWork.HousingDepartamentRepository.Create(mapper.Map<HousingDepartamentEntity>(tariff));

            unitOfWork.SaveChanges();
        }
    }
}
