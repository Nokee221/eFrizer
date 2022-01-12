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
    public class LoyaltyBonusUserService : BaseCRUDService<Model.LoyaltyBonusUser, Database.LoyaltyBonusUser, Model.LoyaltyBonusUserSearchRequest, Model.LoyaltyBonusUserInsertRequest, object>, ILoyaltyBonusUser
    {
        public LoyaltyBonusUserService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async Task<List<Model.LoyaltyBonusUser>> Get([FromBody] LoyaltyBonusUserSearchRequest search = null)
        {

            if(search.ClientId != 0 && search.LoyatlyBonusId != 0)
            {
                var bonuses = await Context.LoyaltyBonusUsers.Where(x => x.ClientId == search.ClientId).Where(x => x.LoyaltyBonusId == search.LoyatlyBonusId).ToListAsync();
                return _mapper.Map<List<Model.LoyaltyBonusUser>>(bonuses);

            }
            else
            {

                var bonuses = await Context.LoyaltyBonusUsers.ToListAsync();

                return _mapper.Map<List<Model.LoyaltyBonusUser>>(bonuses);
            }
        }

        public async Task<Model.LoyaltyBonusUser> Insert(LoyaltyBonusUserInsertRequest request)
        {
            Database.LoyaltyBonusUser entity = new Database.LoyaltyBonusUser();

            entity.ClientId = request.ClientId;
            entity.LoyaltyBonusId = request.LoyaltyBonusId;
            entity.Counter = 1;

            Context.LoyaltyBonusUsers.Add(entity);
            await Context.SaveChangesAsync();


            return _mapper.Map<Model.LoyaltyBonusUser>(entity);
        }
    }
}
