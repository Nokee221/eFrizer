using eFrizer.Model.Service;
using eFrizer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class ServiceController : BaseCRUDController<Model.Service.Service, ServiceSearchRequest, ServiceInsertRequest, ServiceUpdateRequest>
    {
        public ServiceController(IServiceService service) : base(service)
        {

        }
    }
}
