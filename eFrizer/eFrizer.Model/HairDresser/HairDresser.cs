using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class HairDresser
    {
        public int HairDresserId { get; set; }
        public string Name { get; set; }
        public int HairSalonId { get; set; }

        public virtual HairSalon HairSalon { get; set; }
    }
}
