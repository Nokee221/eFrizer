using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public interface ILoyaltyBonusUser : ICRUDService<Model.LoyaltyBonusUser, Model.LoyaltyBonusUserSearchRequest, Model.LoyaltyBonusUserInsertRequest, Model.LoyaltyBonusUserUpdateRequest>
    {
    }
}
