using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class ManagerService : BaseCRUDService<Model.Manager, Database.Manager, object, ManagerInsertRequest, object>, IManagerService
    {
        public ManagerService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {
        }

    }
}
