using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models;
using DataAccessLayer;
using Entities;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Implementation.Services
{
    public class HouseTypeService : IHouseTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public HouseTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<HouseType> GetAllHouseTypes()
        {
            return unitOfWork.HouseTypeRepository.GetAll()
                .Select(houseTypeEntity => mapper.Map<HouseType>(houseTypeEntity));
        }
    }
}