using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int HairDresserId{ get; set; }
        public int ClientId { get; set; }

        public int ServiceId { get; set; }

        public DateTime To { get; set; }
        public DateTime From { get; set; }

        public virtual HairDresser HairDresser { get; set; }
        public virtual Client Client { get; set; }

        public virtual Service Service { get; set; }
    }
}
