using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class HairSalonService
    {
        public int HairSalonServiceId { get; set; }
        public int ServiceId { get; set; }
        public int HairSalonId { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int TimeMin { get; set; }

        public virtual HairSalon HairSalon { get; set; }
        public virtual Service Service { get; set; }
    }
}
