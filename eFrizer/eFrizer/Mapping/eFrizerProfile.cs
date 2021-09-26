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

            CreateMap<Database.Review, Model.Review.Review>().ReverseMap();
            CreateMap<Model.Review.ReviewInsertRequest, Database.Review>().ReverseMap();

            CreateMap<Database.Service, Model.Service.Service>().ReverseMap();
            CreateMap<Model.Service.ServiceInsertRequest, Database.Service>().ReverseMap();

            CreateMap<Database.Reservation, Model.Reservation.Reservation>().ReverseMap();
            CreateMap<Model.Reservation.ReservationInsertRequest, Database.Reservation>().ReverseMap();

            CreateMap<Database.HairSalonService, Model.HairSalonService.HairSalonService>().ReverseMap();
            CreateMap<Model.HairSalonService.HairSalonService, Database.HairSalonService>().ReverseMap();

        }
    }
}
