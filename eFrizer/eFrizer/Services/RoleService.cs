using AutoMapper;
using eFrizer.Database;
using eFrizer.Model.Requests.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class RoleService : BaseCRUDService<Model.Role, Database.Role, RoleSearchRequest, RoleInsertRequest, RoleUpdateRequest>, ICRUDService<Model.Role, RoleSearchRequest, RoleInsertRequest, RoleUpdateRequest>
    {
        public RoleService(eFrizerContext context, IMapper mapper) 
            : base(context, mapper)
        {

        }

        public override List<Model.Role> Get(RoleSearchRequest search = null)
        {
            var entity = Context.Set<Database.Role>().AsQueryable();

            if(!string.IsNullOrWhiteSpace(search?.Name))
            {
                entity = entity.Where(x => x.Name.Contains(search.Name));
            }

            var list = entity.ToList();
            return _mapper.Map<List<Model.Role>>(list);
        }
    }
}
