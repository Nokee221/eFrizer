using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class HairSalonService
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public float Price { get; set; }
        public int TimeMin { get; set; }

        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public string ServiceName => Service?.Name;

        public int HairSalonId { get; set; }
        public virtual HairSalon HairSalon { get; set; }

        public int ImageId { get; set; }
    }
}
