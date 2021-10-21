using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class ReservationInsertRequest
    {
        public int HairDresserId { get; set; }
        public int ClientId { get; set; }

        public int ServiceId { get; set; }

        public DateTime To { get; set; }
        public DateTime From { get; set; }
    }
}
