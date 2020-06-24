using Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Implementation.Repositories
{
    public class FlatRepository : Repository<FlatEntity, int>, IFlatRepository
    {
        public FlatRepository(HeadOfOSBBContext appContext) : base(appContext) { }

        public override IEnumerable<FlatEntity> GetAll()
        {
            return entities.Include(flatEntity => flatEntity.House).ThenInclude(houseEntity => houseEntity.Type)
                .Include(flatEntity => flatEntity.Owner);
        }
    }
}
