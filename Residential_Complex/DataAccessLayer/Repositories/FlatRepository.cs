using ResidentialComplex.DataAccessLayer.Entities;
using ResidentialComplex.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ResidentialComplex.DataAccessLayer.Repositories
{
    public class FlatRepository : Repository<FlatEntity, int>, IFlatRepository
    {
        public FlatRepository(HeadOfOSBBContext appContext) : base(appContext) { }

        public override IEnumerable<FlatEntity> GetAll()
        {
            return entities.Include(flatEntity => flatEntity.House).Include(flatEntity => flatEntity.Owner);
        }
    }
}
