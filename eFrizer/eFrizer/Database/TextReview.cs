using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Database
{
    public class TextReview
    {
        public int TextReviewId { get; set; }
        public int HairSalonId { get; set; }
        public int ClientId { get; set; }
        public string Text { get; set; }

        public virtual Client Client { get; set; }
        public virtual HairSalon HairSalon { get; set; }
    }
}
