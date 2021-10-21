using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class Reservation
    {
        public int HairDresserId{ get; set; }
        public int ClientId { get; set; }

        public Service Service { get; set; }

        public DateTime To { get; set; }
        public DateTime From { get; set; }

        public virtual HairDresser ApplicationUser { get; set; }
        public virtual Client Client { get; set; }
    }
}
