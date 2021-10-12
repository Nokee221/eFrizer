using AutoMapper;
using eFrizer.Database;

namespace eFrizer.Services
{
    public class HairSalonHairDresserService : BaseCRUDService<Model.HairSalonHairDresser, Database.HairSalonHairDresser, object, Model.HairSalonHairDresserInsertRequest, object>, IHairSalonHairDresserService
    {
        public HairSalonHairDresserService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
    }
}