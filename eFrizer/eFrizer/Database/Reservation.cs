using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int HairDresserId { get; set; }
        public int ApplicationUserId { get; set; }
        public DateTime Time { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual HairDresser HairDresser { get; set; }
    }
}
