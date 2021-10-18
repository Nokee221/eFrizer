using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class ClientInsertRequest : ApplicationUserInsertRequest
    {
        public string Description { get; set; }
    }
}
