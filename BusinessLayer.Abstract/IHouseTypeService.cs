using System.Collections.Generic;
using Models;

namespace BusinessLayer.Abstract
{
    public interface IHouseTypeService
    {
        IEnumerable<HouseType> GetAllHouseTypes();
    }
}
