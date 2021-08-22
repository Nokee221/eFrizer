using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class City
    {
        public City()
        {
            HairSalonCities = new HashSet<HairSalonCity>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<HairSalonCity> HairSalonCities { get; set; }
    }
}
