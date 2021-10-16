using eFrizer.Model;
using eFrizer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class HairSalonServiceController : BaseCRUDController<Model.HairSalonService , HairSalonServiceSearchRequest, HairSalonServiceInsertRequest, object>
    {
        public HairSalonServiceController(ICRUDService<Model.HairSalonService, HairSalonServiceSearchRequest, HairSalonServiceInsertRequest, object> service)
            : base(service)
        {

        }
    }
}
