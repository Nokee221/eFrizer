using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class HairSalonManager
    {
        public int HairSalonId { get; set; }
        public int ManagerId { get; set; }

        public virtual HairSalon HairSalon { get; set; }
        public virtual Manager Manager { get; set; }

        public string HairSalonName => HairSalon?.Name;
        public string HairSalonDescription => HairSalon?.Description;
        public string HairSalonAddress => HairSalon?.Address;
    }
}
