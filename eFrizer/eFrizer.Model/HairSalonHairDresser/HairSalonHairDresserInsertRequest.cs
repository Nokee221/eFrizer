using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class HairSalonHairDresserInsertRequest
    {
        public int HairSalonId { get; set; }
        public int HairDresserId { get; set; }
        public string WorkingFrom { get; set; }
        public string WorkingTo { get; set; }
    }
}
