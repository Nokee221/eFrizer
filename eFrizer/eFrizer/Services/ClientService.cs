using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using eFrizer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class ClientService : BaseCRUDService<Model.Client, Database.Client, ClientSearchRequest, ClientInsertRequest, ClientUpdateRequest>, IClientService
    {
        public ClientService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {
        }

        
    }
}
