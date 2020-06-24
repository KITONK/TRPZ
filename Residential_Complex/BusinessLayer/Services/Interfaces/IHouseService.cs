using System.Collections.Generic;

namespace ResidentialComplex.BusinessLayer.Services
{
    public interface IHouseService
    {
        IEnumerable<int> GetNumberOfHouse();
    }
}
