using System;
using System.Collections.Generic;

namespace eFrizer.Database
{
    public class HairDresser : ApplicationUser
    {
        public int HairSalonId { get; set; }
        public virtual HairSalon HairSalon { get; set; }
    }
}
