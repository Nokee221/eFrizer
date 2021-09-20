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
        }
    }
}
