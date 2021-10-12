using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class HairSalonHairDresser
    {
        public int HairSalonId { get; set; }
        public int HairDresserId { get; set; }
        public virtual HairSalon HairSalon { get; set; }
        public virtual HairDresser HairDresser { get; set; }
    }
}
