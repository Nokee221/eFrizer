using AutoMapper;
using eFrizer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class RoleService : BaseCRUDService<Model.Role, Database.Role, object, object, object>, ICRUDService<Model.Role, object, object, object>
    {
        public RoleService(eFrizerContext context, IMapper mapper) 
            : base(context, mapper)
        {

        }
    }
}
