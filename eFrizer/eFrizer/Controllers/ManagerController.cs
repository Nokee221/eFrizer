using eFrizer.Model;
using eFrizer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class ManagerController : BaseCRUDController<Model.Manager, object, ManagerInsertRequest, ManagerUpdateRequest>
    {
        public ManagerController(IManagerService service) : base(service)
        {
        }
    }
}
