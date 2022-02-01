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
    public class HairSalonServiceService : BaseCRUDService<Model.HairSalonService, Database.HairSalonService, HairSalonServiceSearchRequest, HairSalonServiceInsertRequest, HairSalonServiceUpdateRequest>, IHairSalonServiceService
    {
        public HairSalonServiceService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {

        }

        public async override Task<List<Model.HairSalonService>> Get([FromBody] HairSalonServiceSearchRequest search = null)
        {
            if (search.HairSalonId != 0)
            {
                var list = await Context.HairSalonServices.Where(x => x.HairSalonId == search.HairSalonId).Include(x => x.Service).ToListAsync();
                return _mapper.Map<List<Model.HairSalonService>>(list);
            }
            else
            {
                if (!string.IsNullOrEmpty(search?.Name))
                {
                    var list2 = await Context.HairSalonServices.Where(x => x.Service.Name == search.Name).Include(x => x.Service).ToListAsync();
                    return _mapper.Map<List<Model.HairSalonService>>(list2);
                }
                else
                {
                    var list = await Context.HairSalonServices.Include(x => x.Service).ToListAsync();
                    return _mapper.Map<List<Model.HairSalonService>>(list);
                }
            }
        }


        public async override Task<Model.HairSalonService> Insert([FromBody]HairSalonServiceInsertRequest request)
        {
            var entitiy = _mapper.Map<Database.Service>(request);
            Context.Services.Add(entitiy);
            await Context.SaveChangesAsync();


            Database.HairSalonService hairSalonService = new Database.HairSalonService()
            {
                HairSalonId = request.HairSalonId,
                ServiceId = entitiy.ServiceId
            };

            Context.HairSalonServices.Add(hairSalonService);
            await Context.SaveChangesAsync();


            return _mapper.Map<Model.HairSalonService>(hairSalonService);

        }
    }
}
