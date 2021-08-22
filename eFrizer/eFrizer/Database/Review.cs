using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int HairSalonId { get; set; }
        public int ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual HairSalon HairSalon { get; set; }
    }
}
