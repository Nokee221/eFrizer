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
        public IClientService clientService { get; set; }

        public ClientController(IClientService service) : base(service)
        {
            clientService = service;
        }

        [HttpGet("/Recommend")]
        public async Task<List<Model.HairSalon>> Recommend(int clientId)
        {
            var salons = await clientService.Recommend(clientId);
            return salons;
        }
    }
}
