﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class HairSalonServiceInsertRequest : ServiceInsertRequest
    {
        public int ServicesId { get; set; }
        public int HairSalonId { get; set; }
    }
}
