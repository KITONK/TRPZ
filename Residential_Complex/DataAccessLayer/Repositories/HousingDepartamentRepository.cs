using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ResidentialComplex.DataAccessLayer.Entities;
using ResidentialComplex.DataAccessLayer.Repositories;

namespace ResidentialComplex.DataAccessLayer.Repositories
{
    public class HousingDepartamentRepository : Repository<HousingDepartamentEntity, int>, IHousingDepartamentRepository
    {
        public HousingDepartamentRepository(HeadOfOSBBContext appContext) : base(appContext) { }

        public override IEnumerable<HousingDepartamentEntity> GetAll()
        {
            return entities
                .Include(hd => hd.Flat)
                .Include(hd => hd.Flat.Owner)
                .Include(hd => hd.Flat.House);
        }
    }
}
