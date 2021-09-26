using AutoMapper;
using eFrizer.Database;
using eFrizer.Model.HairSalonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class HairSalonServiceService : BaseCRUDService<Model.HairSalonService.HairSalonService, Database.HairSalonService, object, HairSalonServiceInsertRequest, object>, ICRUDService<Model.HairSalonService.HairSalonService, object, HairSalonServiceInsertRequest, object>
    {
        public HairSalonServiceService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {

        }
    }
}
