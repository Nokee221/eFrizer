using AutoMapper;
using eFrizer.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eFrizer.Services
{
    
    public class BaseReadService<T, TDb, TSearch> : IReadService<T, TSearch> where T : class where TDb : class where TSearch : class
    {
        public eFrizerContext Context { get; set; }
        protected readonly IMapper _mapper;

        public BaseReadService(eFrizerContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public async virtual Task<List<T>> Get([FromBody]TSearch search = null)
        {
            var entity = Context.Set<TDb>();

            var list = await entity.ToListAsync();
            return _mapper.Map<List<T>>(list);
        }

        public async virtual Task<T> GetById(int id)
        {
            var set = Context.Set<TDb>();
            var entity = await set.FindAsync(id);
            return _mapper.Map<T>(entity);
        }
    }
    
}
