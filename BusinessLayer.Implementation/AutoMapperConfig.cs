using Models;
using Entities;
using AutoMapper;

namespace BusinessLayer.Implementation
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //Для того, чтобы связать слой данных со слоем бизнес используем автомаппер
            //Создает свой маппер, я пишу какие у меня модели и ентити будут мапиться и 
            //отображаться друг на друга и оно идет автоматически в контейнеры
            CreateMap<OwnerEntity, Owner>().ReverseMap();
            CreateMap<HouseTypeEntity, HouseType>().ReverseMap();
            //Сопоставляем идентификатор класса ентити с идентификатором класса модель
            CreateMap<HouseEntity, House>();
            CreateMap<House, HouseEntity>()
                .ForMember(houseEntity => houseEntity.TypeId, cfg => cfg.MapFrom(house => house.Type.Id))
                .ForMember(houseEntity => houseEntity.Type, cfg => cfg.Ignore());
            //переводит с класса в ентити и наоборот
            CreateMap<FlatEntity, Flat>();
            CreateMap<Flat, FlatEntity>()
                .ForMember(flatEntity => flatEntity.OwnerId, cfg => cfg.MapFrom(flat => flat.Owner.Id))
                .ForMember(flatEntity => flatEntity.HouseId, cfg => cfg.MapFrom(flat => flat.House.Id))
                .ForMember(flatEntity => flatEntity.Owner, cfg => cfg.Ignore())
                .ForMember(flatEntity => flatEntity.House, cfg => cfg.Ignore());

            CreateMap<HousingDepartamentEntity, HousingDepartament>();
            CreateMap<HousingDepartament, HousingDepartamentEntity>()
                .ForMember(hdEntity => hdEntity.FlatId, cfg => cfg.MapFrom(hd => hd.Flat.Id))
                .ForMember(hdEntity => hdEntity.Flat, cfg => cfg.Ignore());
        }
    }
}
