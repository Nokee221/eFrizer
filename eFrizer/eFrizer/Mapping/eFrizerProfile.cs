using AutoMapper;


namespace eFrizer.Mapping
{
    public class eFrizerProfile : Profile
    {
        public eFrizerProfile()
        {
            CreateMap<Database.HairSalon, Model.HairSalon>().ReverseMap();
        }
    }
}
