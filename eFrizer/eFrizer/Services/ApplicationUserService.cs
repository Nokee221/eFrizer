using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class ApplicationUserService : BaseCRUDService<Model.ApplicationUser, Database.ApplicationUser, object, ApplicationUserInsertRequest, object>, ICRUDService<Model.ApplicationUser, object, ApplicationUserInsertRequest, object>
    {
        public ApplicationUserService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
    }
}
