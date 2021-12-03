using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class HairSalonServiceLoyaltyBonusInsertRequest
    {
        public int HairSalonServiceId { get; set; }
        public int Discount { get; set; }
        public int ActivatesOn { get; set; }
        public int ExpiresIn { get; set; }
    }
}
