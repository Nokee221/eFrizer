using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model.Review
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int HairSalonId { get; set; }
        public int ApplicationUserId { get; set; }
        public string Text { get; set; }
        public int StarRating { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual HairSalon HairSalon { get; set; }
    }
}
