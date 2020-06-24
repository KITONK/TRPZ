using ResidentialComplex.DataAccessLayer.Entities;
using ResidentialComplex.DataAccessLayer.Repositories;

namespace ResidentialComplex.DataAccessLayer
{
    public interface IUnitOfWork
    {
        IHousingDepartamentRepository HousingDepartamentRepository { get; }
        IFlatRepository FlatRepository { get; }
        IHouseRepository HouseRepository { get; }

        void SaveChanges();
    }
}
