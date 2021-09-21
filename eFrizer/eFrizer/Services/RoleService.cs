﻿using AutoMapper;
using eFrizer.Database;
using eFrizer.Model.Requests.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class RoleService : BaseCRUDService<Model.Role, Database.Role, object, RoleInsertRequest, RoleUpdateRequest>, ICRUDService<Model.Role, object, RoleInsertRequest, RoleUpdateRequest>
    {
        public RoleService(eFrizerContext context, IMapper mapper) 
            : base(context, mapper)
        {

        }
    }
}