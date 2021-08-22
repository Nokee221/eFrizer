using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class HairSalonType
    {
        public HairSalonType()
        {
            HairSalonHairSalonTypes = new HashSet<HairSalonHairSalonType>();
        }

        public int HairSalonTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<HairSalonHairSalonType> HairSalonHairSalonTypes { get; set; }
    }
}
