using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class HairSalonServiceService : BaseCRUDService<Model.HairSalonService, Database.HairSalonService, object, HairSalonServiceInsertRequest, object>, ICRUDService<Model.HairSalonService, object, HairSalonServiceInsertRequest, object>
    {
        public HairSalonServiceService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {

        }
    }
}
