using System;
using System.Collections.Generic;

#nullable disable

namespace eFrizer.Database
{
    public partial class ApplicationUser
    {
        public ApplicationUser()
        {
            ApplicationUserRoles = new HashSet<ApplicationUserRole>();
            Reservations = new HashSet<Reservation>();
            Reviews = new HashSet<Review>();
        }

        public int ApplicationUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }

        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
