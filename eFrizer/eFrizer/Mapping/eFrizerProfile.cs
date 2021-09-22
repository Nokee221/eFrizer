using AutoMapper;
using eFrizer.Model;

namespace eFrizer.Mapping
{
    public class eFrizerProfile : Profile
    {
        public eFrizerProfile()
        {
            CreateMap<Database.HairSalon, Model.HairSalon>().ReverseMap();
            CreateMap<Model.HairSalonInsertRequest, Database.HairSalon>().ReverseMap();

            CreateMap<Database.City, Model.City>().ReverseMap().ReverseMap();
            CreateMap<Model.CityInsertRequest, Database.City>().ReverseMap();

            CreateMap<Database.HairSalonCity, Model.HairSalonCity>().ReverseMap();
            CreateMap<Model.HairSalonCityInsertRequest, Database.HairSalonCity>().ReverseMap();

            CreateMap<Database.ApplicationUser, Model.ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUserInsertRequest, Database.ApplicationUser>();

            CreateMap<Database.HairDresser, Model.HairDresser>().ReverseMap();
            CreateMap<Model.HairDresserInsertRequest, Database.HairDresser>().ReverseMap();

            //TODO: is reverse map always necessary and is there anything bad in over-using it?
            CreateMap<Database.Role, Model.Role>().ReverseMap();
            CreateMap<Model.RoleInsertRequest, Database.Role>().ReverseMap();
            CreateMap<Model.RoleUpdateRequest, Database.Role>().ReverseMap();
            CreateMap<Model.RoleSearchRequest, Database.Role>().ReverseMap();

            CreateMap<Database.ApplicationUserRole, Model.ApplicationUserRole>().ReverseMap();
            CreateMap<Model.ApplicationUserRoleInsertRequest, Database.ApplicationUserRole>().ReverseMap();

        }
    }
}
