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

            context.SaveChanges();
        }
    }
}
