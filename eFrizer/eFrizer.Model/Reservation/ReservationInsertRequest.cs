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
        public string To { get; set; }

        public string From { get; set; }
    }
}
