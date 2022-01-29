using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class ReviewInsertRequest
    {
        public int HairSalonId { get; set; }
        public int ClientId { get; set; }
        public int StarRating { get; set; }
    }
}
