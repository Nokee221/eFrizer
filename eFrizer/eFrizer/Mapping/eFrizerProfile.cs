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

            CreateMap<Database.HairDresser, Model.HairDresser.HairDresser>().ReverseMap();
            CreateMap<Model.HairDresser.HairDresserInsertRequest, Database.HairDresser>().ReverseMap();

            //TODO: is reverse map always necessary and is there anything bad in over-using it?
            CreateMap<Database.Role, Model.Role>().ReverseMap();
            CreateMap<Model.Requests.Role.RoleInsertRequest, Database.Role>().ReverseMap();
            CreateMap<Model.Requests.Role.RoleUpdateRequest, Database.Role>().ReverseMap();

        }
    }
}
