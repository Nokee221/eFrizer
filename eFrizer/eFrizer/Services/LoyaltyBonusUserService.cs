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
    public class LoyaltyBonusUserService : BaseCRUDService<Model.LoyaltyBonusUser, Database.LoyaltyBonusUser, object, Model.LoyaltyBonusUser, object>, ILoyaltyBonusUser
    {
        public LoyaltyBonusUserService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async override Task<List<Model.LoyaltyBonusUser>> Get([FromBody] object search = null)
        {
            var bonuses = await Context.LoyaltyBonusUsers.ToListAsync();

            return _mapper.Map<List<Model.LoyaltyBonusUser>>(bonuses);
        }

        public async Task<Model.LoyaltyBonusUser> Insert(LoyaltyBonusUserInsertRequest request)
        {
            Database.LoyaltyBonusUser entity = new Database.LoyaltyBonusUser();

            entity.ClientId = request.ClientId;
            entity.LoyaltyBonusId = request.LoyaltyBonusId;
            entity.Counter = 0;

            Context.LoyaltyBonusUsers.Add(entity);
            await Context.SaveChangesAsync();


            return _mapper.Map<Model.LoyaltyBonusUser>(entity);
        }
    }
}
