using System;
using System.Collections.Generic;
using System.Text;

//TODO: all endpoints should have a separate namespace for their requests
namespace eFrizer.Model.Requests
{
    public class ApplicationUserInsertRequest
    {
        public int ApplicationUserId { get; set; }
    }
}
