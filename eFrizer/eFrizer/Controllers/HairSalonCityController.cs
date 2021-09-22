using eFrizer.Model;
using eFrizer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class HairSalonCityController : BaseCRUDController<HairSalonCity, object, HairSalonCityInsertRequest, object>
    {
        public HairSalonCityController(ICRUDService<HairSalonCity, object, HairSalonCityInsertRequest, object> service)
            : base(service)
        {

        }
    }
}
