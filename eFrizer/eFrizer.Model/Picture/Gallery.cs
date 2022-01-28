using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class Gallery
    {
        public class Row
        {
            public int pictureId;
        }
        public List<Row> Rows{ get; set; }
        public int[] pictureIds { get; set; }
    }
}
