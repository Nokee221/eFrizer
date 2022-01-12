using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Database
{
    public class LoyaltyBonusUser
    {
        public int Id { get; set; }

        public int LoyaltyBonusId { get; set; }

        public int ClientId { get; set; }

        public virtual HairSalonServiceLoyaltyBonus hairSalonServiceLoyaltyBonus { get; set; }

        public virtual Client Client { get; set; }

        public int Counter { get; set; }
    }
        
}
