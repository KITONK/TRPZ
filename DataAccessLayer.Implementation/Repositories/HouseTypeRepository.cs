using Entities;
using System;
using System.Collections.Generic;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Implementation.Repositories
{
    public class HouseTypeRepository : Repository<HouseTypeEntity, int>, IHouseTypeRepository
    {
        public HouseTypeRepository(HeadOfOSBBContext appContext) : base(appContext) { }
    }
}
