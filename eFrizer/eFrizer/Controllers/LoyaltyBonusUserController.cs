using eFrizer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class LoyaltyBonusUserController : BaseCRUDController<Model.LoyaltyBonusUser, Model.LoyaltyBonusUserSearchRequest, Model.LoyaltyBonusUserInsertRequest, Model.LoyaltyBonusUserUpdateRequest>
    {
        private readonly ILoyaltyBonusUser service;
        public LoyaltyBonusUserController(ILoyaltyBonusUser service) : base(service)
        {
            this.service = service;
        }
    }
}
