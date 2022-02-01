using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class HairSalonServiceUpdateRequest
    {
        public string Description { get; set; }
        public int Price { get; set; }
        public int TimeMin { get; set; }
        public string Name { get; set; }
    }
}
