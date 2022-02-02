using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Database
{
    public class HairSalonServicePicture
    {
        public int PictureId { get; set; }
        public int HairSalonServiceId { get; set; }

        public virtual HairSalonService HairSalonService { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
