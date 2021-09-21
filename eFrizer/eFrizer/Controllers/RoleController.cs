using eFrizer.Model;
using eFrizer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class RoleController : BaseCRUDController<Model.Role, RoleSearchRequest, RoleInsertRequest, RoleUpdateRequest>
    {
        //TODO: 1)the service interface passed below should be made into a separate one 2)service interfaces should have a special namespace
        public RoleController(ICRUDService<Model.Role, RoleSearchRequest, RoleInsertRequest, RoleUpdateRequest> service) : base(service)
        {

        }
    }
}
