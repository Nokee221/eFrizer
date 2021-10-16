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
            CreateMap<Model.HairSalonUpdateRequest, Database.HairSalon>().ReverseMap();

            CreateMap<Model.HairSalonManagerInsertRequest, Database.HairSalon>().ReverseMap();
            

            CreateMap<Database.City, Model.City>().ReverseMap().ReverseMap();
            CreateMap<Model.CityInsertRequest, Database.City>().ReverseMap();

            CreateMap<Database.HairSalonType, Model.HairSalonType>().ReverseMap();
            CreateMap<Model.HairSalonTypeInsertRequest, Database.HairSalonType>().ReverseMap();

            CreateMap<Database.HairSalonHairSalonType, Model.HairSalonHairSalonType>().ReverseMap();
            CreateMap<Model.HairSalonHairSalonTypeInsertRequest, Database.HairSalonHairSalonType>().ReverseMap();

            CreateMap<Database.ApplicationUser, Model.ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUserInsertRequest, Database.ApplicationUser>();
            CreateMap<ApplicationUserUpdateRequest, Database.ApplicationUser>();

            CreateMap<Database.HairDresser, Model.HairDresser>().ReverseMap();
            CreateMap<Model.HairDresserInsertRequest, Database.HairDresser>().ReverseMap();

            //TODO: is reverse map always necessary and is there anything bad in over-using it?
            CreateMap<Database.Role, Model.Role>().ReverseMap();
            CreateMap<Model.RoleInsertRequest, Database.Role>().ReverseMap();
            CreateMap<Model.RoleUpdateRequest, Database.Role>().ReverseMap();
            

            CreateMap<Database.ApplicationUserRole, Model.ApplicationUserRole>().ReverseMap();
            CreateMap<Model.ApplicationUserRoleInsertRequest, Database.ApplicationUserRole>().ReverseMap();

            CreateMap<Database.Picture, Model.Picture>().ReverseMap();
            CreateMap<Model.PictureInsertRequest, Database.Picture>().ReverseMap();
            CreateMap<Model.PictureUpdateRequest, Database.Picture>().ReverseMap();

            CreateMap<Database.HairSalonPicture, Model.HairSalonPicture>().ReverseMap();
            CreateMap<Model.HairSalonPictureInsertRequest, Database.HairSalonPicture>().ReverseMap();
            CreateMap<Model.HairSalonPictureUpdateRequest, Database.HairSalonPicture>().ReverseMap();

            CreateMap<Database.Review, Model.Review>().ReverseMap();
            CreateMap<Model.ReviewInsertRequest, Database.Review>().ReverseMap();

            CreateMap<Database.Service, Model.Service>().ReverseMap();
            CreateMap<Model.ServiceInsertRequest, Database.Service>().ReverseMap();
            CreateMap<Model.ServiceUpdateRequest, Database.Service>().ReverseMap();

            CreateMap<Database.Reservation, Model.Reservation>().ReverseMap();
            CreateMap<Model.ReservationInsertRequest, Database.Reservation>().ReverseMap();

            CreateMap<Database.HairSalonService, Model.HairSalonService>().ReverseMap();
            CreateMap<Model.HairSalonService, Database.HairSalonService>().ReverseMap();
            CreateMap<Model.HairSalonServiceInsertRequest, Database.HairSalonService>().ReverseMap();



            CreateMap<Database.HairSalonHairDresser, Model.HairSalonHairDresser>().ReverseMap();
            CreateMap<Model.HairSalonHairDresserInsertRequest, Database.HairSalonHairDresser>().ReverseMap();

            CreateMap<Database.Manager, Model.Manager>().ReverseMap();
            CreateMap<Model.ManagerInsertRequest, Database.Manager>().ReverseMap();
            CreateMap<Model.ManagerUpadateRequest, Database.Manager>().ReverseMap();

            CreateMap<Database.HairSalonManager, Model.HairSalonManager>().ReverseMap();
            CreateMap<Model.HairSalonManagerInsertRequest, Database.HairSalonManager>().ReverseMap();

        }
    }
}
