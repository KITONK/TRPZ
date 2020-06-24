using Models;
using System.Collections.Generic;
using System;

namespace BusinessLayer.Abstract
{
    public interface IHousingDepartamentService
    {
        IEnumerable<HousingDepartament> GetHousingDepartaments();
        void SaveTariff(HousingDepartament tariff);
    }
}
