using eFrizer.Model;
using eFrizer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class ApplicationUserController : BaseCRUDController<Model.ApplicationUser, ApplicationUserSearchRequest, ApplicationUserInsertRequest, object>
    {
        public ApplicationUserController(IApplicationUserService service)
            : base(service)
        {

        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public override Task<List<ApplicationUser>> Get([FromQuery] ApplicationUserSearchRequest search)
        {
            return base.Get(search);
        }
    }
}
