using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class HairSalonHairSalonType
    {
        public int HairSalonId { get; set; }
        public int HairSalonTypeId { get; set; }

        public virtual HairSalon HairSalon { get; set; }
        public virtual HairSalonType HairSalonType { get; set; }
    }
}
