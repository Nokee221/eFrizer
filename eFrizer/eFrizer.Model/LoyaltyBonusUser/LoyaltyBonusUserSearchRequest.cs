using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class LoyaltyBonusUserSearchRequest
    {
        public int ClientId { get; set; }

        public int HairSalonServiceLoyaltyBonusId { get; set; }

        public int HairSalonServiceId { get; set; }
    }
}
