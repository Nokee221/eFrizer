using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int HairSalonId { get; set; }
        public int ClientId { get; set; }

        public string Text { get; set; }
        public int StarRating { get; set; }

        public virtual Client Client { get; set; }
        public virtual HairSalon HairSalon { get; set; }
    }
}
