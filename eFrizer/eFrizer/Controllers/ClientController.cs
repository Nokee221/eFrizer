using eFrizer.Model;
using eFrizer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class ClientController : BaseCRUDController<Model.Client, ClientSearchRequest, ClientInsertRequest, ClientUpdateRequest>
    {
        public ClientController(IClientService service) : base(service)
        {
        }
    }
}
