using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;

namespace eFrizer.Services
{
    public class HairSalonHairSalonTypeService : BaseCRUDService<Model.HairSalonHairSalonType, Database.HairSalonHairSalonType, object, HairSalonHairSalonTypeInsertRequest, object>, ICRUDService<Model.HairSalonHairSalonType, object, HairSalonHairSalonTypeInsertRequest, object>
    {
        public HairSalonHairSalonTypeService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
    }
}
