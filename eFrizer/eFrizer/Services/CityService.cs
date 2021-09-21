using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class CityService : BaseCRUDService<Model.City, Database.City, Model.CitySearchRequest, Model.CityInsertRequest, Model.CityUpdateRequest>, ICityService
    {
        public CityService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {
        }

        public override IEnumerable<Model.City> Get(CitySearchRequest search = null)
        {
            var entity = Context.Set<Database.City>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                entity = entity.Where(x => x.Name.Contains(search.Name));
            }

            var list = entity.ToList();

            return _mapper.Map<List<Model.City>>(list);
        }

    }
}
