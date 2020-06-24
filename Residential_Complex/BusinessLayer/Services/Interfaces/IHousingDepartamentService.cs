using ResidentialComplex.BusinessLayer.DomainModel;
using System.Collections.Generic;

namespace ResidentialComplex.BusinessLayer.Services
{
    public interface IHousingDepartamentService
    {
        IEnumerable<HousingDepartament> GetHousingDepartaments();
        void SaveTariffs(IEnumerable<HousingDepartament> tariffs);
    }
}
