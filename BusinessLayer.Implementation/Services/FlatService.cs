using AutoMapper;
using Models;
using Entities;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Implementation.Services
{
    public class FlatService : IFlatService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        //для взаемодействия со слоем данных в сервисах, я использую интерфейс юнита и таким
        //образом я внедряю Dependency Injection
        public FlatService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<Flat> GetFlatsByHouseTypeId(int houseTypeId)
        {
            return unitOfWork.FlatRepository.GetAll()
                .Select(flatEntity => mapper.Map<Flat>(flatEntity))
                .Where(flat => flat.House.Type.Id == houseTypeId);
        }


    }
}
