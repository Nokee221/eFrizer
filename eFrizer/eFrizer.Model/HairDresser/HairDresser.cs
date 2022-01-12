using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class HairDresser : ApplicationUser
    {
        public string Type => "Hair Dresser";
        public int HairSalonId;
        public virtual HairSalon HairSalon { get; set; }
    }
}
