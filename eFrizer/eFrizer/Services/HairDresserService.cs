using AutoMapper;
using eFrizer.Database;
using eFrizer.Model.HairDresser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class HairDresserService : BaseCRUDService<Model.HairDresser.HairDresser, Database.HairDresser, HairDresserSearchRequest, HairDresserInsertRequest, HairDresserUpdateRequest>, IHairDresserService
    {
        public HairDresserService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {
        }


        public override IEnumerable<Model.HairDresser.HairDresser> Get(HairDresserSearchRequest search = null)
        {
            var entity = Context.Set<Database.HairDresser>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                entity = entity.Where(x => x.Name.Contains(search.Name));
            }

            var list = entity.ToList();

            return _mapper.Map<List<Model.HairDresser.HairDresser>>(list);
        }
    }
}
