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
    public class HairSalonServiceLoyaltyBonusService
        : BaseCRUDService<Model.HairSalonServiceLoyaltyBonus, Database.HairSalonServiceLoyaltyBonus, Model.HairSalonServiceLoyaltyBonusSearchRequest, Model.HairSalonServiceLoyaltyBonusInsertRequest, object>, IHairSalonServiceLoyaltyBonusService
    {
        public HairSalonServiceLoyaltyBonusService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async override Task<List<Model.HairSalonServiceLoyaltyBonus>> Get([FromBody] HairSalonServiceLoyaltyBonusSearchRequest search = null)
        {
            if(search.hairSalonId != 0)
            {
                var bonuses = await Context.HairSalonServiceLoyaltyBonuses.Where(x => x.Service.HairSalonId == search.hairSalonId).Include(x => x.Service).ThenInclude(x => x.Service).ToListAsync();
                return _mapper.Map<List<Model.HairSalonServiceLoyaltyBonus>>(bonuses);
            }
            else
            {
                var bonuses = await Context.HairSalonServiceLoyaltyBonuses
                .Include(x => x.Service)
                .ThenInclude(x => x.Service)
                .ToListAsync();

                return _mapper.Map<List<Model.HairSalonServiceLoyaltyBonus>>(bonuses);
            }

        }
    }
}
