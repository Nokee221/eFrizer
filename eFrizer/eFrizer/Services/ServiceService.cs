using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class ServiceService : BaseCRUDService<Model.Service, Database.Service, ServiceSearchRequest, ServiceInsertRequest, ServiceUpdateRequest>, IServiceService
    {
        public ServiceService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {
        }


        public async override Task<List<Model.Service>> Get(ServiceSearchRequest search = null)
        {
            var entity = Context.Set<Database.Service>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                entity = entity.Where(x => x.Name.Contains(search.Name));
            }

            var list = await entity.ToListAsync();

            return _mapper.Map<List<Model.Service>>(list);
        }
    }
}
