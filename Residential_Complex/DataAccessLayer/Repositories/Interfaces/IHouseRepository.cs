﻿using ResidentialComplex.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentialComplex.DataAccessLayer.Repositories
{
    public interface IHouseRepository : IRepository<HouseEntity, int>
    {

    }
}
