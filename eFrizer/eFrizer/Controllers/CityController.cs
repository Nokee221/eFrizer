using eFrizer.Model;
using eFrizer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class CityController : BaseCRUDController<Model.City, CitySearchRequest, CityInsertRequest, CityUpdateRequest>
    {
        public CityController(ICityService service) : base(service)
        {
        }
    }
}
