using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;

namespace eFrizer.Services
{
    public class HairSalonTypeService : BaseCRUDService<Model.HairSalonType, Database.HairSalonType, object, HairSalonTypeInsertRequest, object>, ICRUDService<Model.HairSalonType, object, HairSalonTypeInsertRequest, object>
    {
        public HairSalonTypeService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
    }
}