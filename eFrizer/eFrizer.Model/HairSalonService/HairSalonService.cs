using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class HairSalonService
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }
        public int HairSalonId { get; set; }

        public virtual HairSalon HairSalon { get; set; }
        
        public virtual Service Service { get; set; }


        public string ServiceName => Service?.Name;

        public string ServiceDescription => Service?.Description;
        
        public float ?ServicePrice => Service?.Price;
        public float ?ServiceTime => Service?.TimeMin;
    }
}
