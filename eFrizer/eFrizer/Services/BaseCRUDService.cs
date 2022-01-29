using AutoMapper;
using eFrizer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace eFrizer.Services
{

    public class BaseCRUDService<T, TDb, TSearch, TInsert, TUpdate> : BaseReadService<T, TDb, TSearch>, ICRUDService<T, TSearch, TInsert, TUpdate> where T : class where TSearch : class where TInsert : class where TUpdate : class where TDb : class
    {
        public BaseCRUDService(eFrizerContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async virtual Task<T> Insert(TInsert request)
        {
            var set = Context.Set<TDb>();

            TDb entity = _mapper.Map<TDb>(request);

            set.Add(entity);

            await Context.SaveChangesAsync();

            return _mapper.Map<T>(entity);
        }
        //TODO: is there any price paid by declaring all of these endpoints async?
        public async virtual Task<T> Update(int id, TUpdate request)
        {
            var set = Context.Set<TDb>();

            var entity = set.Find(id);

            _mapper.Map(request, entity);

            await Context.SaveChangesAsync();

            return _mapper.Map<T>(entity);
        }

        public async virtual Task<T> Delete(int id)
        {
            var set = Context.Set<TDb>();

            var entity = await set.FindAsync(id);

            set.Remove(entity);

            await Context.SaveChangesAsync();

            return _mapper.Map<T>(entity);
        }


    }



}
