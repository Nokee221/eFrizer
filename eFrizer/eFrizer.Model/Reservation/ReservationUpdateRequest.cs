﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class ReservationUpdateRequest
    {
        public int HairDresserId { get; set; }
        public int ApplicationUserId { get; set; }
        public DateTime To { get; set; }
        public DateTime From { get; set; }
    }
}
