using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class HairSalonService : BaseCRUDService<Model.HairSalon, Database.HairSalon, HairSalonSearchRequest, HairSalonInsertRequest, HairSalonUpdateRequest>, IHairSalonService
    {
        public HairSalonService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {
        }

        public override IEnumerable<Model.HairSalon> Get(HairSalonSearchRequest search = null)
        {
            var entity = Context.Set<Database.HairSalon>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                entity = entity.Where(x => x.Name.Contains(search.Name));
            }

            var list = entity.ToList();

            return _mapper.Map<List<Model.HairSalon>>(list);
        }
    }
}
