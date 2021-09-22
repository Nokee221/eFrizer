using eFrizer.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer
{
    public class SetupService
    {
        public void Init(eFrizerContext context)
        {
            context.Database.Migrate();

            if (!context.HairSalons.Any(x => x.Name == "Amar"))
            {
                context.HairSalons.Add(new HairSalon() { Name = "Amar" , Address = "mejdan", Description = "Pravo dobars"});
            }

            if(!context.Roles.Any(x => x.Name == "Administrator"))
            {
                context.Roles.Add(new Role() { Name = "Administrator" });
            }

            if (!context.Roles.Any(x => x.Name == "Manager"))
            {
                context.Roles.Add(new Role() { Name = "Manager" });
            }

            if (!context.Roles.Any(x => x.Name == "Client"))
            {
                context.Roles.Add(new Role() { Name = "Client" });
            }

            if (!context.Roles.Any(x => x.Name == "HairDresser"))
            {
                context.Roles.Add(new Role() { Name = "HairDresser" });
            }

            if(!context.ApplicationUsers.Any(x => x.Name == "User A"))
            {
                context.ApplicationUsers.Add(new ApplicationUser() { Name = "User A", Surname = "A User", Username = "auser" });
            }

            if (!context.ApplicationUsers.Any(x => x.Name == "User M"))
            {
                context.ApplicationUsers.Add(new ApplicationUser() { Name = "User M", Surname = "M User", Username = "muser" });
            }

            if (!context.ApplicationUsers.Any(x => x.Name == "User H"))
            {
                context.ApplicationUsers.Add(new ApplicationUser() { Name = "User H", Surname = "H User", Username = "huser" });
            }

            if (!context.ApplicationUsers.Any(x => x.Name == "User C"))
            {
                context.ApplicationUsers.Add(new ApplicationUser() { Name = "User C", Surname = "C User", Username = "cuser" });
            }

            context.SaveChanges();

            if(!context.ApplicationUserRoles.Any(x => x.ApplicationUser.Name == "User A" && x.Role.Name == "Administrator"))
            {
                context.ApplicationUserRoles.Add(new ApplicationUserRole()
                {
                    ApplicationUserId = context.ApplicationUsers.Where(x => x.Name == "User A").First().ApplicationUserId,
                    RoleId = context.Roles.Where(x => x.Name == "Administrator").First().RoleId
                });
            }

            if (!context.ApplicationUserRoles.Any(x => x.ApplicationUser.Name == "User M" && x.Role.Name == "Manager"))
            {
                context.ApplicationUserRoles.Add(new ApplicationUserRole()
                {
                    ApplicationUserId = context.ApplicationUsers.Where(x => x.Name == "User M").First().ApplicationUserId,
                    RoleId = context.Roles.Where(x => x.Name == "Manager").First().RoleId
                });
            }

            if (!context.ApplicationUserRoles.Any(x => x.ApplicationUser.Name == "User H" && x.Role.Name == "HairDresser"))
            {
                context.ApplicationUserRoles.Add(new ApplicationUserRole()
                {
                    ApplicationUserId = context.ApplicationUsers.Where(x => x.Name == "User H").First().ApplicationUserId,
                    RoleId = context.Roles.Where(x => x.Name == "HairDresser").First().RoleId
                });
            }

            if (!context.ApplicationUserRoles.Any(x => x.ApplicationUser.Name == "User C" && x.Role.Name == "Client"))
            {
                context.ApplicationUserRoles.Add(new ApplicationUserRole()
                {
                    ApplicationUserId = context.ApplicationUsers.Where(x => x.Name == "User C").First().ApplicationUserId,
                    RoleId = context.Roles.Where(x => x.Name == "Client").First().RoleId
                });
            }

            context.SaveChanges();
        }
    }
}
