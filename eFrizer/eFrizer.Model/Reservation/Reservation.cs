using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public int HairDresserId { get; set; }
        public virtual HairDresser HairDresser { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int HairSalonServiceId { get; set; }
        public virtual HairSalonService HairSalonService { get; set; }
        
        public DateTime To { get; set; }
        public DateTime From { get; set; }
        
        public string HairDresserName => HairDresser?.Name;
        public string ClientUsername => Client?.Username;
        public string ServiceName => HairSalonService?.Service?.Name;
    }
}
