using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    class PictureInsertRequest
    {
        public IFormFile ImageFile { get; set; }
    }
}
