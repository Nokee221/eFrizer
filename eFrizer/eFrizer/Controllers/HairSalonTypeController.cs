using eFrizer.Model;
using eFrizer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class HairSalonTypeController : BaseCRUDController<HairSalonType, object, HairSalonTypeInsertRequest, object>
    {
        public HairSalonTypeController(ICRUDService<HairSalonType, object, HairSalonTypeInsertRequest, object> service)
            : base(service)
        {

        }
    }
}
