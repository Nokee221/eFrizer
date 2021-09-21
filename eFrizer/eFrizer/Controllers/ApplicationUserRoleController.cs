using eFrizer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class ApplicationUserRoleController : BaseCRUDController<Model.ApplicationUserRole, object, object, object>
    {
        public ApplicationUserRoleController(ICRUDService<Model.ApplicationUserRole, object, object, object> service)
            : base(service)
        {

        }
    }
}
