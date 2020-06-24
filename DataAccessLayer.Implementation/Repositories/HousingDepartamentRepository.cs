using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Entities;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Implementation.Repositories
{
    public class HousingDepartamentRepository : Repository<HousingDepartamentEntity, int>, IHousingDepartamentRepository
    {
        public HousingDepartamentRepository(HeadOfOSBBContext appContext) : base(appContext) { }

        public override IEnumerable<HousingDepartamentEntity> GetAll()
        {
            return entities
                .Include(hd => hd.Flat)
                .Include(hd => hd.Flat.Owner)
                .Include(hd => hd.Flat.House).ThenInclude(house => house.Type);
        }
    }
}
