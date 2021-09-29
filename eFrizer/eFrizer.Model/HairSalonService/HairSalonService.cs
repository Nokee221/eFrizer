using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class HairSalonService
    {
        public int ServicesId { get; set; }
        public int HairSalonId { get; set; }

        public virtual HairSalon HairSalon { get; set; }
        
        public virtual Service Services { get; set; }
    }
}
