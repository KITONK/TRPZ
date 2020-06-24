using Models;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IFlatService
    {
        IEnumerable<Flat> GetFlatsByHouseTypeId(int houseTypeId);
    }
}
