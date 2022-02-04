using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using Microsoft.EntityFrameworkCore;
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

        public async override Task<List<Model.HairSalon>> Get(HairSalonSearchRequest search = null)
        {
            var entity = Context.Set<Database.HairSalon>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                entity = entity.Where(x => x.Name.Contains(search.Name));
            }

            var list = await entity.ToListAsync();

            var hairSalons = _mapper.Map<List<Model.HairSalon>>(list);

            foreach (var hairSalon in hairSalons)
            {
                hairSalon.FeaturedPictureId = Context.HairSalonPictures.Where(x => x.HairSalonId == hairSalon.HairSalonId).First().PictureId;
            }

            return hairSalons;
        }
    }
}
