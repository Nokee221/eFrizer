using eFrizer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class LoyaltyBonusUserController : BaseCRUDController<Model.LoyaltyBonusUser, object, Model.LoyaltyBonusUserInsertRequest, object>
    {
        public LoyaltyBonusUserController(ILoyaltyBonusUser service) : base(service)
        {

        }
    }
}
