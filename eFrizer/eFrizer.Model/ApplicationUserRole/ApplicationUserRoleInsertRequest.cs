using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public class ApplicationUserRoleInsertRequest
    {
        public int ApplicationUserId { get; set; }
        public int RoleId { get; set; }
    }
}
