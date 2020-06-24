using ResidentialComplex.BusinessLayer.DomainModel;
using System.Collections.Generic;

namespace ResidentialComplex.BusinessLayer.Services
{
    public interface IFlatService
    {
        IEnumerable<Flat> GetFlats(int numberOfHouse);
    }
}
