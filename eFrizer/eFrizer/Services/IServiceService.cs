using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public interface IServiceService : ICRUDService<Model.Service, ServiceSearchRequest, ServiceInsertRequest, ServiceUpdateRequest>
    {
    }
}
