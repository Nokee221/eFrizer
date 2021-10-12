using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class HairSalonManagerService : BaseCRUDService<Model.HairSalonManager, Database.HairSalonManager, HairSalonManagerSearchRequest, HairSalonManagerInsertRequest, object>, ICRUDService<Model.HairSalonManager, HairSalonManagerSearchRequest, HairSalonManagerInsertRequest, object>
    {
        public HairSalonManagerService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async override Task<List<Model.HairSalonManager>> Get([FromBody] HairSalonManagerSearchRequest search = null)
        {
            if(search.ManagerId != 0)
            {
                var list = await Context.HairSalonManagers.Where(x => x.ManagerId == search.ManagerId).Include(x => x.HairSalon).ToListAsync();
                return _mapper.Map<List<Model.HairSalonManager>>(list);
            }
            else
            {

                var list = await Context.HairSalonManagers.ToListAsync();
                return _mapper.Map<List<Model.HairSalonManager>>(list);
            }
        }
    }
}
