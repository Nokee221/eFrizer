using eFrizer.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public interface IServiceService : ICRUDService<Model.Service.Service, ServiceSearchRequest, ServiceInsertRequest, ServiceUpdateRequest>
    {
    }
}
