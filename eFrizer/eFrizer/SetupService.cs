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

            context.SaveChanges();

            if (!context.Services.Any(x => x.Name == "Šišanje"))
            {
                context.Services.Add(new Service() { Name = "Šišanje", Description = "Muško šišanje" });
            }

            if (!context.Services.Any(x => x.Name == "Farbanje"))
            {
                context.Services.Add(new Service() { Name = "Farbanje", Description = "Muško farbanje" });
            }

            if (!context.Services.Any(x => x.Name == "Brijanje"))
            {
                context.Services.Add(new Service() { Name = "Brijanje", Description = "Muško brijanje" });
            }

            context.SaveChanges();


            

        }
    }
}
