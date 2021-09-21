using eFrizer.Model;
using eFrizer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class ApplicationUserRoleController : BaseCRUDController<ApplicationUserRole, object, ApplicationUserRoleInsertRequest, object>
    {
        public ApplicationUserRoleController(ICRUDService<ApplicationUserRole, object, ApplicationUserRoleInsertRequest, object> service)
            : base(service)
        {

        }
    }
}
