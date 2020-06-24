using ResidentialComplex.DataAccessLayer.Repositories;

namespace ResidentialComplex.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HeadOfOSBBContext appContext;

        public IHousingDepartamentRepository HousingDepartamentRepository { get; }
        public IFlatRepository FlatRepository { get; }
        public IHouseRepository HouseRepository { get; }

        public UnitOfWork(HeadOfOSBBContext appContext, IHousingDepartamentRepository housingDepartamentRepository, IFlatRepository flatRepository, IHouseRepository houseRepository)
        {
            this.appContext = appContext;
            HousingDepartamentRepository = housingDepartamentRepository;
            FlatRepository = flatRepository;
            HouseRepository = houseRepository;
        }

        public void SaveChanges()
        {
            appContext.SaveChanges();
        }
    }
}
