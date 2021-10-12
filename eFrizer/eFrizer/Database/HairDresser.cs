using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class HairDresser
    {
        public HairDresser()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int HairDresserId { get; set; }

        public string Name { get; set; }
        public int HairSalonId { get; set; }

        public virtual HairSalon HairSalon { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
