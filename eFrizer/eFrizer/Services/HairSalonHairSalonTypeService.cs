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
    public class HairSalonHairSalonTypeService : BaseCRUDService<Model.HairSalonHairSalonType, Database.HairSalonHairSalonType, HairSalonHairSalonTypeSearchRequest, HairSalonHairSalonTypeInsertRequest, object>, ICRUDService<Model.HairSalonHairSalonType, HairSalonHairSalonTypeSearchRequest, HairSalonHairSalonTypeInsertRequest, object>
    {
        public HairSalonHairSalonTypeService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async Task<List<Model.HairSalonHairSalonType>> Get([FromQuery] HairSalonHairSalonTypeSearchRequest search)
        {
            if(search.HairSalonId != 0)
            {
                var list = await Context.HairSalonHairSalonTypes.Where(x => x.HairSalonId == search.HairSalonId).Include(x => x.HairSalonType).ToListAsync();
                return _mapper.Map<List<Model.HairSalonHairSalonType>>(list);
            }
            else if(search.HairSalonTypeId != 0)
            {
                var list = await Context.HairSalonHairSalonTypes.Where(x => x.HairSalonTypeId == search.HairSalonTypeId).Include(x => x.HairSalon).ToListAsync();
                return _mapper.Map<List<Model.HairSalonHairSalonType>>(list);
            }
            else
            {
                var list = await Context.HairSalonHairSalonTypes.ToListAsync();
                return _mapper.Map<List<Model.HairSalonHairSalonType>>(list);
            }
        }

        public async override Task<Model.HairSalonHairSalonType> Insert(HairSalonHairSalonTypeInsertRequest request)
        {
            var entitiy = _mapper.Map<Database.HairSalonType>(request);

            if(!Context.HairSalonTypes.Any(x => x.Name == entitiy.Name))
            {
                Context.HairSalonTypes.Add(entitiy);
                await Context.SaveChangesAsync();
            }

            Database.HairSalonHairSalonType hairsalonhairsalontype = new Database.HairSalonHairSalonType();
            hairsalonhairsalontype.HairSalonId = request.HairSalonId;
            hairsalonhairsalontype.HairSalonTypeId = entitiy.HairSalonTypeId;


            if(!Context.HairSalonHairSalonTypes.Any(x => x.HairSalonType.Name == request.Name))
            {

                Context.HairSalonHairSalonTypes.Add(hairsalonhairsalontype);
                await Context.SaveChangesAsync();

                return _mapper.Map<Model.HairSalonHairSalonType>(hairsalonhairsalontype);
            }

          
            return _mapper.Map<Model.HairSalonHairSalonType>(hairsalonhairsalontype);

        }
    }
}
