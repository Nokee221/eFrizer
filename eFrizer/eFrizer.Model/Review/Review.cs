using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int HairSalonId { get; set; }
        public int ClientId { get; set; }
        public int StarRating { get; set; }

        public virtual Client Client { get; set; }
        public virtual HairSalon HairSalon { get; set; }


        public string HairSalonName => HairSalon?.Name;
        public string ClientName => Client?.Username;
    }
}
