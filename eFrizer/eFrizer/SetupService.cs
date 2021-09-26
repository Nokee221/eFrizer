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

            if (!context.HairSalons.Any(x => x.Name == "Studio RAS"))
            {
                context.HairSalons.Add(new HairSalon() { Name = "Studio RAS" , Address = "Mejdandžik 8", Description = "Pravo dobar frizerski."});
            }

            if (!context.HairSalons.Any(x => x.Name == "Partner"))
            {
                context.HairSalons.Add(new HairSalon() { Name = "Partner", Address = "Maršala Tita 21", Description = "Pravo dobar frizerski salon za muškarce i žene." });
            }

            if (!context.HairSalonTypes.Any(x => x.Name == "Ženski"))
            {
                context.HairSalonTypes.Add(new HairSalonType() { Name = "Ženski" });
            }

            if (!context.HairSalonTypes.Any(x => x.Name == "Muški"))
            {
                context.HairSalonTypes.Add(new HairSalonType() { Name = "Muški" });
            }

            //TODO: Separate each data type seed into a function
            if (!context.Cities.Any(x => x.Name == "Zenica"))
            {
                context.Cities.Add(new City() { Name = "Zenica" });
            }

            if (!context.Cities.Any(x => x.Name == "Sarajevo"))
            {
                context.Cities.Add(new City() { Name = "Sarajevo" });
            }

            if (!context.Cities.Any(x => x.Name == "Banja Luka"))
            {
                context.Cities.Add(new City() { Name = "Banja Luka" });
            }

            context.SaveChanges();

            if(!context.HairSalonCities.Any(x => x.HairSalon.Name == "Studio RAS" && x.City.Name == "Zenica"))
            {
                context.Add(new HairSalonCity()
                {
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Studio RAS").First().HairSalonId,
                    CityId = context.Cities.Where(x => x.Name == "Zenica").First().CityId
                });
            }

            if(!context.HairSalonHairSalonTypes.Any(x => x.HairSalon.Name == "Studio RAS" && x.HairSalonType.Name == "Ženski"))
            {
                context.Add(new HairSalonHairSalonType()
                {
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Studio RAS").First().HairSalonId,
                    HairSalonTypeId = context.HairSalonTypes.Where(x => x.Name == "Ženski").First().HairSalonTypeId
                });
            }

            if (!context.HairSalonHairSalonTypes.Any(x => x.HairSalon.Name == "Partner" && x.HairSalonType.Name == "Muški"))
            {
                context.Add(new HairSalonHairSalonType()
                {
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Partner").First().HairSalonId,
                    HairSalonTypeId = context.HairSalonTypes.Where(x => x.Name == "Muški").First().HairSalonTypeId
                });
            }

            if (!context.HairSalonHairSalonTypes.Any(x => x.HairSalon.Name == "Partner" && x.HairSalonType.Name == "Ženski"))
            {
                context.Add(new HairSalonHairSalonType()
                {
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Partner").First().HairSalonId,
                    HairSalonTypeId = context.HairSalonTypes.Where(x => x.Name == "Ženski").First().HairSalonTypeId
                });
            }

            if (!context.Roles.Any(x => x.Name == "Administrator"))
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

            if (!context.Reviews.Any(x => x.ApplicationUser.Name == "User A" && x.HairSalon.Name == "Studio RAS" && x.Text == "Najbolji salon u gradu!!"))
            {
                context.Reviews.Add(new Review()
                {
                    ApplicationUserId = context.ApplicationUsers.Where(x => x.Name == "User A").First().ApplicationUserId,
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Studio RAS").First().HairSalonId,
                    Text = "Najbolji salon u gradu!!"

                });
            }

            context.SaveChanges();


        }
    }
}
