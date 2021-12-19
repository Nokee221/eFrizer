using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public partial class HairSalonHairSalonType
    {
        public int HairSalonId { get; set; }
        public int HairSalonTypeId { get; set; }

        public virtual HairSalon HairSalon { get; set; }
        public virtual HairSalonType HairSalonType { get; set; }

        public string HairSalonTypeName => HairSalonType?.Name;
        public string HairSalonName => HairSalon?.Name;

        public string HairSalonAdress => HairSalon?.Address;
    }
}
