using eFrizer.Model;
using eFrizer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class HairSalonManagerController : BaseCRUDController<HairSalonManager, HairSalonManagerSearchRequest, HairSalonManagerInsertRequest, object>
    {
        public HairSalonManagerController(ICRUDService<HairSalonManager, HairSalonManagerSearchRequest, HairSalonManagerInsertRequest, object> service)
           : base(service)
        {

        }

       
    }
}
