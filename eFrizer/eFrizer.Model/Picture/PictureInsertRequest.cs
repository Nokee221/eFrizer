﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class PictureInsertRequest
    {
        public IFormFile ImageFile { get; set; }
    }
}