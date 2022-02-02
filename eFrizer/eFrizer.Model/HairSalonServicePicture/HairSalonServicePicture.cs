using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class HairSalonServicePicture
    {
        public int PictureId { get; set; }
        public int HairSalonServiceId { get; set; }

        public virtual HairSalonService HairSalonService { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
