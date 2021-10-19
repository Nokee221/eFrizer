using eFrizer.Model;
using eFrizer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class HairSalonHairSalonTypeController : BaseCRUDController<HairSalonHairSalonType, HairSalonHairSalonTypeSearchRequest, HairSalonHairSalonTypeInsertRequest, object>
    {
        public HairSalonHairSalonTypeController(ICRUDService<HairSalonHairSalonType, HairSalonHairSalonTypeSearchRequest, HairSalonHairSalonTypeInsertRequest, object> service)
            : base(service)
        {

        }
    }
}
