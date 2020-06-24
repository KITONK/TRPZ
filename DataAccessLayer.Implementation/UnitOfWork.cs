using DataAccessLayer.Abstract;

namespace DataAccessLayer.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HeadOfOSBBContext appContext;

        public IHousingDepartamentRepository HousingDepartamentRepository { get; }
        public IFlatRepository FlatRepository { get; }
        public IHouseTypeRepository HouseTypeRepository { get; }

        //передаю это через конструктор, то есть Dependency Injection через конструктор
        //оно везде будет одинаково и я передаю не конкретную реализацию, а уже интерфейсы этих репозиториев 
        public UnitOfWork(HeadOfOSBBContext appContext, IHousingDepartamentRepository housingDepartamentRepository, IFlatRepository flatRepository, IHouseTypeRepository houseTypeRepository)
        {
            this.appContext = appContext;
            HousingDepartamentRepository = housingDepartamentRepository;
            FlatRepository = flatRepository;
            HouseTypeRepository = houseTypeRepository;
        }

        public void SaveChanges()
        {
            appContext.SaveChanges();
        }
    }
}
