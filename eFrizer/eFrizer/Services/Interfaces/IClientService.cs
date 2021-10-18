using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services.Interfaces
{
    public interface IClientService : ICRUDService<Model.Client, ClientSearchRequest, ClientInsertRequest, ClientUpdateRequest>
    {
    
    }
}
