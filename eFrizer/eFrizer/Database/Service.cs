using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class Service
    {
        public Service()
        {
            HairSalonServices = new HashSet<HairSalonService>();
        }

        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public float Price { get; set; }

        public virtual ICollection<HairSalonService> HairSalonServices { get; set; }
    }
}
