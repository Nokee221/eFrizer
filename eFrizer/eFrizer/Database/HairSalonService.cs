using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class HairSalonService
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int HairSalonId { get; set; }

        public virtual HairSalon HairSalon { get; set; }
        public virtual Service Service { get; set; }
    }
}
