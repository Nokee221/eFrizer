using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class Picture
    {
        public Picture()
        {
            HairSalonPictures = new HashSet<HairSalonPicture>();
        }

        public int PictureId { get; set; }

        public virtual ICollection<HairSalonPicture> HairSalonPictures { get; set; }
    }
}
