using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class HairSalonManagerInsertRequest : HairSalonInsertRequest
    {
        public int HairSalonId { get; set; }
        public int ManagerId { get; set; }
    }
}
