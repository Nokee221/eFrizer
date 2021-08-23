using AutoMapper;
using eFrizer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class ApplicationUserService : BaseCRUDService<Model.ApplicationUser, Database.ApplicationUser, object, Model.Requests.ApplicationUserInsertRequest, object>, ICRUDService<Model.ApplicationUser, object, Model.Requests.ApplicationUserInsertRequest, object>
    {
        public ApplicationUserService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
    }
}
