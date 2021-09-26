using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model.Reservation
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int HairDresserId { get; set; }
        public int ApplicationUserId { get; set; }
        public DateTime To { get; set; }
        public DateTime From { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        
        public virtual HairDresser.HairDresser HairDresser { get; set; }
    }
}
