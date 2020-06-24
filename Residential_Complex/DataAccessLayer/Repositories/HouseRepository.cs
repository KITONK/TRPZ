using ResidentialComplex.DataAccessLayer.Entities;
using ResidentialComplex.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;

namespace ResidentialComplex.DataAccessLayer.Repositories
{
    public class HouseRepository : Repository<HouseEntity, int>, IHouseRepository
    {
        public HouseRepository(HeadOfOSBBContext appContext) : base(appContext) { }
    }
}
