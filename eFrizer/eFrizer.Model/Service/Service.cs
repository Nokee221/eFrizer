using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public float Price { get; set; }

        public int TimeMin { get; set; }
    }
}
