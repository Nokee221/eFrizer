using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model.HairSalonService
{
    public class HairSalonService
    {
        public int ServicesId { get; set; }
        public int HairSalonId { get; set; }

        public virtual HairSalon HairSalon { get; set; }
        
        public virtual Service.Service Services { get; set; }
    }
}
