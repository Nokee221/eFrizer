using eFrizer.Model;
using eFrizer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class ApplicationUserController : BaseCRUDController<Model.ApplicationUser, object, ApplicationUserInsertRequest, object>
    {
        public ApplicationUserController(ICRUDService<Model.ApplicationUser, object, ApplicationUserInsertRequest, object> service)
            : base(service)
        {

        }
    }
}
