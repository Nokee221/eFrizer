using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Database
{
    public class HairSalonHairDresser
    {
        public int HairSalonId { get; set; }
        public int HairDresserId { get; set; }
        public HairSalon HairSalon { get; set; }
        public HairDresser HairDresser { get; set; }
    }
}
