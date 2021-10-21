using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class Reservation
    {
       
        public int HairDresserId { get; set; }
        public int ClientId { get; set; }

        public int ServiceId { get; set; }
        public DateTime To { get; set; }
        public DateTime From { get; set; }

        
        public virtual HairDresser HairDresser { get; set; }
        public virtual Client Client { get; set; }

        public virtual Service Service { get; set; }


        public string HairDresserName => HairDresser?.Name;
        public string ClientUsername => Client?.Username;
        public string ServiceName => Service?.Name;
    }
}
