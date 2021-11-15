using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Database
{
    public class HairSalonServiceLoyaltyBonus
    {
        public int Id { get; set; }
        public int HairSalonServiceId { get; set; }
        public int Discount { get; set; }
        public int ActivatesOn { get; set; }
        public int ExpiresIn { get; set; }
        public virtual HairSalonService Service { get; set; }
    }
}
