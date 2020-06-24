namespace DataAccessLayer.Abstract
{
    public interface IUnitOfWork
    {
        //содержит в себе 3 репозитория
        IHousingDepartamentRepository HousingDepartamentRepository { get; }
        IFlatRepository FlatRepository { get; }
        IHouseTypeRepository HouseTypeRepository { get; }

        void SaveChanges();
    }
}
