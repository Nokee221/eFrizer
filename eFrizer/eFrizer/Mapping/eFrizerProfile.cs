using AutoMapper;


namespace eFrizer.Mapping
{
    public class eFrizerProfile : Profile
    {
        public eFrizerProfile()
        {
            CreateMap<Database.HairSalon, Model.HairSalon>().ReverseMap();

            CreateMap<Model.Requests.HairSalonInsertRequest, Database.HairSalon>().ReverseMap();
            CreateMap<Database.City, Model.City.City>().ReverseMap().ReverseMap();
            CreateMap<Model.City.CityInsertRequest, Database.City>().ReverseMap();

            CreateMap<Database.ApplicationUser, Model.ApplicationUser>().ReverseMap();
            CreateMap<Model.Requests.ApplicationUserInsertRequest, Database.ApplicationUser>();

        }
    }
}
