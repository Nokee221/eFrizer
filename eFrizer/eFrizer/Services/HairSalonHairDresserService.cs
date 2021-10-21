using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class HairSalonHairDresserService : BaseCRUDService<Model.HairSalonHairDresser, Database.HairSalonHairDresser, HairSalonHairDresserSearchRequest, Model.HairSalonHairDresserInsertRequest, object>, IHairSalonHairDresserService
    {
        public HairSalonHairDresserService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async Task<List<Model.HairSalonHairDresser>> Get([FromBody] HairSalonHairDresserSearchRequest search)
        {
            if(search.HairSalonId != 0)
            {
                var list = await Context.HairSalonHairDressers.Where(x => x.HairSalonId == search.HairSalonId).Include(x => x.HairDresser).ToListAsync();
                return _mapper.Map<List<Model.HairSalonHairDresser>>(list);
            }
            else
            {
                var list = await Context.HairSalonHairDressers.ToListAsync();
                return _mapper.Map<List<Model.HairSalonHairDresser>>(list);

            }
        }
    }
}