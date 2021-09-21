using eFrizer.Model;
using eFrizer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class HairDresserController : BaseCRUDController<Model.HairDresser, HairDresserSearchRequest, HairDresserInsertRequest, HairDresserUpdateRequest>
    {
        public HairDresserController(IHairDresserService service) : base(service)
        {
        }
    }
}
