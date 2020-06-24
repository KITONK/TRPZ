using ResidentialComplex.BusinessLayer.DomainModel;
using ResidentialComplex.DataAccessLayer.Entities;
using AutoMapper;

namespace ResidentialComplex.BusinessLayer
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<OwnerEntity, Owner>().ReverseMap();
            CreateMap<HousingDepartamentEntity, HousingDepartament>().ReverseMap();
            CreateMap<HouseEntity, House>().ReverseMap();
            CreateMap<FlatEntity, Flat>().ReverseMap();
        }
    }
}
