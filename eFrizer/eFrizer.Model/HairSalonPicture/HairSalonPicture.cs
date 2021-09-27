using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class HairSalonPicture
    {
        public int PictureId { get; set; }
        public int HairSalonId { get; set; }

        public virtual HairSalon HairSalon { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
