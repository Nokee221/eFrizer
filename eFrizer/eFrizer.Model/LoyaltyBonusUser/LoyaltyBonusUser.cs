using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class LoyaltyBonusUser
    {
        public int Id { get; set; }

        public int HairSalonServiceLoyaltyBonusId { get; set; }

        public int ClientId { get; set; }

        public virtual HairSalonServiceLoyaltyBonus HairSalonServiceLoyaltyBonus { get; set; }

        public virtual Client Client { get; set; }

        public int Counter { get; set; }

        //public int hairsalonServiceId => HairSalonServiceLoyaltyBonus.HairSalonServiceId;

    }
}
