using AutoMapper;
using eFrizer.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class HairSalonServiceLoyaltyBonusService
        : BaseCRUDService<Model.HairSalonServiceLoyaltyBonus, HairSalonServiceLoyaltyBonus, object, Model.HairSalonServiceLoyaltyBonusInsertRequest, object>, IHairSalonServiceLoyaltyBonusService
    {
        public HairSalonServiceLoyaltyBonusService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async override Task<List<Model.HairSalonServiceLoyaltyBonus>> Get([FromBody] object search = null)
        {
            var bonuses = await Context.HairSalonServiceLoyaltyBonuses
                .Include(x => x.Service)
                .ThenInclude(x => x.Service)
                .ToListAsync();

            return _mapper.Map<List<Model.HairSalonServiceLoyaltyBonus>>(bonuses);
        }
    }
}
