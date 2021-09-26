using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class ReviewInsertRequest
    {
        public int HairSalonId { get; set; }
        public int ApplicationUserId { get; set; }
        public string Text { get; set; }
        public int StarRating { get; set; }
    }
}
