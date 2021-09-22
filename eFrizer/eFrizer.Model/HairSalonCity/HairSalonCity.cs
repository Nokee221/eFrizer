using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public partial class HairSalonCity
    {
        public int HairSalonId { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual HairSalon HairSalon { get; set; }
    }
}
