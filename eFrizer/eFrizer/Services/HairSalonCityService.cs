using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class HairSalonCityService : BaseCRUDService<Model.HairSalonCity, Database.HairSalonCity, object, HairSalonCityInsertRequest, object>, ICRUDService<Model.HairSalonCity, object, HairSalonCityInsertRequest, object>
    {
        public HairSalonCityService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
    }
}
