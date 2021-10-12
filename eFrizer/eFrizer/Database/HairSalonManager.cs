using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Database
{
    public class HairSalonManager
    {
        public int HairSalonId { get; set; }
        public int ManagerId { get; set; }

        public virtual HairSalon HairSalon { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
