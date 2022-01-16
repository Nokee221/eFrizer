using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class LoyaltyBonusUserService : BaseCRUDService<Model.LoyaltyBonusUser, Database.LoyaltyBonusUser, Model.LoyaltyBonusUserSearchRequest, Model.LoyaltyBonusUserInsertRequest, Model.LoyaltyBonusUserUpdateRequest>, ILoyaltyBonusUser
    {
        public LoyaltyBonusUserService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async Task<List<Model.LoyaltyBonusUser>> Get([FromBody] LoyaltyBonusUserSearchRequest search = null)
        {

            if(search.ClientId != 0 && search.HairSalonServiceLoyaltyBonusId != 0)
            {
                var bonuses = await Context.LoyaltyBonusUsers.Where(x => x.ClientId == search.ClientId).Where(x => x.HairSalonServiceLoyaltyBonusId == search.HairSalonServiceLoyaltyBonusId).ToListAsync();
                return _mapper.Map<List<Model.LoyaltyBonusUser>>(bonuses);

            }
            else if(search.ClientId != 0 && search.HairSalonServiceId != 0)
            {
                var bonuses = await Context.LoyaltyBonusUsers.Where(x => x.ClientId == search.ClientId).Where(x => x.hairSalonServiceLoyaltyBonus.HairSalonServiceId == search.HairSalonServiceId).Include(x => x.hairSalonServiceLoyaltyBonus).Include(x => x.Client).ToListAsync();
                return _mapper.Map<List<Model.LoyaltyBonusUser>>(bonuses);
            }
            else
            {

                var bonuses = await Context.LoyaltyBonusUsers.Include(x => x.hairSalonServiceLoyaltyBonus).Include(x => x.Client).ToListAsync();

                return _mapper.Map<List<Model.LoyaltyBonusUser>>(bonuses);
            }
        }

        public async Task<Model.LoyaltyBonusUser> Insert(LoyaltyBonusUserInsertRequest request)
        {
            Database.LoyaltyBonusUser entity = new Database.LoyaltyBonusUser();

            entity.ClientId = request.ClientId;
            entity.HairSalonServiceLoyaltyBonusId = request.HairSalonServiceLoyaltyBonusId;
            entity.Counter = 1;

            Context.LoyaltyBonusUsers.Add(entity);
            await Context.SaveChangesAsync();


            return _mapper.Map<Model.LoyaltyBonusUser>(entity);
        }

        public async Task<Model.LoyaltyBonusUser> Update(int id, [FromBody] LoyaltyBonusUserUpdateRequest request)
        {
            var entity = Context.LoyaltyBonusUsers.Find(id);
            _mapper.Map(request, entity);

            Context.SaveChanges();
            return _mapper.Map<Model.LoyaltyBonusUser>(entity);
        }
    }
}
