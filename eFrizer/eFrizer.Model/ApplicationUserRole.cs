using System;
using System.Collections.Generic;
using System.Text;

namespace eFrizer.Model
{
    public partial class ApplicationUserRole
    {
        public int ApplicationUserId { get; set; }
        public int RoleId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Role Role { get; set; }
    }
}
