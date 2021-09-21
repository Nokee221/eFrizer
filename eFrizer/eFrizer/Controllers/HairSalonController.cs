using eFrizer.Model;
using eFrizer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace eFrizer.Controllers
{
    public class HairSalonController : BaseCRUDController<Model.HairSalon, HairSalonSearchRequest, HairSalonInsertRequest, HairSalonUpdateRequest>
    {
        public HairSalonController(IHairSalonService service) : base(service)
        {
        }
    }
}
