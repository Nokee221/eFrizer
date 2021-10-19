

using System.Collections.Generic;

namespace eFrizer.Model
{
    public partial class ApplicationUser
    {
        //TODO: Create search and put requests for this 
        public int ApplicationUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        //TODO: Why is this, on a GET Application Users Request, showing only the role of the currently logged in user but not other user roles?
        //When the authentication is disabled, this does not happen. What does the BasicAuthHandler do that triggers this type of behaviour?
        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
