using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class Role
    {
        public Role()
        {
            ApplicationUserRoles = new HashSet<ApplicationUserRole>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
