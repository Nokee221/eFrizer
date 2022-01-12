using eFrizer.Database;
using eFrizer.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace eFrizer
{
    public class SetupService
    {
        private IWebHostEnvironment _hostEnvironment;
        private eFrizerContext context;

        public SetupService(IWebHostEnvironment environment, eFrizerContext _context)
        {
            //TODO: make the naming consistent
            _hostEnvironment = environment;
            context = _context;
        }

        public void Init()
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            var password = "1234";
            var salt = AuthHelper.GenerateSalt();
            var hash = AuthHelper.GenerateHash(salt, password);

            //independent objects
            CitySeed();
            HairSalonSeed();
            HairSalonTypeSeed();
            PictureSeed();
            ServiceSeed();
            RoleSeed();
            
            //users
            AdminSeed(salt, hash);
            ManagerSeed(salt, hash);
            ClientSeed(salt, hash);
            HairDresserSeed(salt, hash);
            
            //many-to-many
            ApplicationUserRoleSeed();
            HairSalonManagerSeed();
            HairSalonHairTypeSeed();
            HairSalonServiceSeed();
            HairSalonPictureSeed();
            ReviewSeed();
            


            //if (!context.Reservations.Any(x => x.ApplicationUser.Name == "User A" && x.HairDresser.Name == "Kenan" && x.From == new DateTime(2021 , 4, 26 , 12 , 30, 0) && x.To == new DateTime(2021,4,26,13,0,0)))
            //{
            //    context.Reservations.Add(new Reservation()
            //    {
            //        ApplicationUserId = context.ApplicationUsers.Where(x => x.Name == "User A").First().ApplicationUserId,
            //        HairDresserId = context.HairDressers.Where(x => x.Name == "Kenan").First().HairDresserId,
            //        From = new DateTime(2021, 4, 26, 12, 30, 0),
            //        To = new DateTime(2021, 4, 26, 13, 0, 0)
            //    });
            //}


        }

        private void AdminSeed(string salt, string hash)
        {
            if (!context.ApplicationUsers.Any(x => x.Name == "User A"))
            {
                var user = new ApplicationUser()
                {
                    Name = "User A",
                    Surname = "A User",
                    Username = "auser",
                    PasswordSalt = salt,
                    PasswordHash = hash
                };

                context.ApplicationUsers.Add(user);
            }

            if (!context.ApplicationUsers.Any(x => x.Name == "User A2"))
            {
                var user = new ApplicationUser()
                {
                    Name = "User A2",
                    Surname = "A2 User",
                    Username = "a2user",
                    PasswordSalt = salt,
                    PasswordHash = hash
                };

                context.ApplicationUsers.Add(user);
            }

            context.SaveChanges();
        }

        private void HairSalonServiceSeed()
        {
            if (!context.HairSalonServices.Any(x => x.HairSalon.Name == "Hair Salon 1" && x.Service.Name == "Šišanje"))
            {
                context.HairSalonServices.Add(new HairSalonService()
                {
                    ServiceId = context.Services.Where(x => x.Name == "Šišanje").First().ServiceId,
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 1").First().HairSalonId,


                });
            }

            if (!context.HairSalonServices.Any(x => x.HairSalon.Name == "Hair Salon 2" && x.Service.Name == "Farbanje"))
            {
                context.HairSalonServices.Add(new HairSalonService()
                {
                    ServiceId = context.Services.Where(x => x.Name == "Farbanje").First().ServiceId,
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 2").First().HairSalonId,


                });
            }

            context.SaveChanges();
        }

        private void ReviewSeed()
        {
            if (!context.Reviews.Any(x => x.Client.Name == "Client A" && x.HairSalon.Name == "Hair Salon 1" && x.Text == "Najbolji salon u gradu!!"))
            {
                context.Reviews.Add(new Review()
                {
                    ClientId = context.Clients.Where(x => x.Name == "Client A").First().ApplicationUserId,
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 1").First().HairSalonId,
                    Text = "Najbolji salon u gradu!!"

                });
            }

            context.SaveChanges();

            var fakeReviews = new List<Review>();
            var clientsQuery = context.Clients.AsEnumerable();
            var clients = clientsQuery.OrderBy(x => x.ApplicationUserId).TakeLast(19).ToList();
            var hairSalonsQuery = context.HairSalons.AsEnumerable();
            var hairSalons = hairSalonsQuery.ToList();

            foreach (var client in clients)
            {
                foreach (var hairSalon in hairSalons)
                {
                    fakeReviews.Add(new Review
                    {
                        ClientId = client.ApplicationUserId,
                        HairSalonId = hairSalon.HairSalonId,
                        StarRating = Faker.RandomNumber.Next(1, 5),
                        Text = Faker.Lorem.Paragraph()
                    });
                }
            }

            context.AddRange(fakeReviews);

            context.SaveChanges();
        }

        private void ServiceSeed()
        {
            if (!context.Services.Any(x => x.Name == "Šišanje"))
            {
                context.Services.Add(new Service() { Name = "Šišanje", Description = "Muško šišanje" , Price = 10 , TimeMin = 30 });
            }

            if (!context.Services.Any(x => x.Name == "Farbanje"))
            {
                context.Services.Add(new Service() { Name = "Farbanje", Description = "Muško farbanje", Price= 40 , TimeMin = 60 });
            }

            if (!context.Services.Any(x => x.Name == "Brijanje"))
            {
                context.Services.Add(new Service() { Name = "Brijanje", Description = "Muško brijanje", Price = 7 , TimeMin = 30 });
            }

            context.SaveChanges();
        }

        private void HairSalonPictureSeed()
        {
            if (!context.HairSalonPictures.Any(x => x.HairSalon.Name == "Hair Salon 1" && x.Picture.Path == _hostEnvironment.ContentRootPath + "Images/" + "SlikaA"))
            {
                context.HairSalonPictures.Add(new HairSalonPicture()
                {
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 1").First().HairSalonId,
                    PictureId = context.Pictures.Where(x => x.Path == Path.Combine(_hostEnvironment.ContentRootPath + "Images/" + "SlikaA")).First().PictureId,
                });
            }

            if (!context.HairSalonPictures.Any(x => x.HairSalon.Name == "Hair Salon 2" && x.Picture.Path == _hostEnvironment.ContentRootPath + "Images/" + "SlikaB"))
            {
                context.HairSalonPictures.Add(new HairSalonPicture()
                {
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 2").First().HairSalonId,
                    PictureId = context.Pictures.Where(x => x.Path == Path.Combine(_hostEnvironment.ContentRootPath + "Images/" + "SlikaB")).First().PictureId,
                });
            }

            if (!context.HairSalonPictures.Any(x => x.HairSalon.Name == "Hair Salon 2" && x.Picture.Path == _hostEnvironment.ContentRootPath + "Images/" + "SlikaC"))
            {
                context.HairSalonPictures.Add(new HairSalonPicture()
                {
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 2").First().HairSalonId,
                    PictureId = context.Pictures.Where(x => x.Path == Path.Combine(_hostEnvironment.ContentRootPath + "Images/" + "SlikaC")).First().PictureId,
                });
            }

            context.SaveChanges();
        }

        private void ApplicationUserRoleSeed()
        {
            if (!context.ApplicationUserRoles.Any(x => x.ApplicationUser.Name == "User A" && x.Role.Name == "Administrator"))
            {
                var row = new ApplicationUserRole()
                {
                    ApplicationUserId = context.ApplicationUsers.Where(x => x.Name == "User A").First().ApplicationUserId,
                    RoleId = context.Roles.Where(x => x.Name == "Administrator").First().RoleId
                };

                context.ApplicationUserRoles.Add(row);
            }

            context.SaveChanges();

            if (!context.ApplicationUserRoles.Any(x => x.ApplicationUser.Name == "User A2" && x.Role.Name == "Administrator"))
            {
                var row = new ApplicationUserRole()
                {
                    ApplicationUserId = context.ApplicationUsers.Where(x => x.Name == "User A2").First().ApplicationUserId,
                    RoleId = context.Roles.Where(x => x.Name == "Administrator").First().RoleId
                };

                context.ApplicationUserRoles.Add(row);
            }

            context.SaveChanges();

            if (!context.ApplicationUserRoles.Any(x => x.ApplicationUser.Name == "User M" && x.Role.Name == "Manager"))
            {
                var row = new ApplicationUserRole()
                {
                    ApplicationUserId = context.ApplicationUsers.Where(x => x.Name == "User M").First().ApplicationUserId,
                    RoleId = context.Roles.Where(x => x.Name == "Manager").First().RoleId
                };

                context.ApplicationUserRoles.Add(row);
            }

            context.SaveChanges();

            if (!context.ApplicationUserRoles.Any(x => x.ApplicationUser.Name == "User M2" && x.Role.Name == "Manager"))
            {
                var row = new ApplicationUserRole()
                {
                    ApplicationUserId = context.ApplicationUsers.Where(x => x.Name == "User M2").First().ApplicationUserId,
                    RoleId = context.Roles.Where(x => x.Name == "Manager").First().RoleId
                };

                context.ApplicationUserRoles.Add(row);
            }

            context.SaveChanges();
            
            if (!context.ApplicationUserRoles.Any(x => x.ApplicationUser.Name == "Hair Dresser 1" && x.Role.Name == "HairDresser"))
            {
                var row = new ApplicationUserRole()
                {
                    ApplicationUserId = context.ApplicationUsers.Where(x => x.Name == "Hair Dresser 1").First().ApplicationUserId,
                    RoleId = context.Roles.Where(x => x.Name == "HairDresser").First().RoleId
                };

                context.ApplicationUserRoles.Add(row);
            }



            if (!context.ApplicationUserRoles.Any(x => x.ApplicationUser.Name == "Client A" && x.Role.Name == "Client"))
            {
                var row = new ApplicationUserRole()
                {
                    ApplicationUserId = context.ApplicationUsers.Where(x => x.Name == "Client A").First().ApplicationUserId,
                    RoleId = context.Roles.Where(x => x.Name == "Client").First().RoleId
                };

                context.ApplicationUserRoles.Add(row);
            }

            context.SaveChanges();
        }

        private void HairSalonManagerSeed()
        {
            if (!context.HairSalonManagers.Any(x => x.HairSalon.Name == "Hair Salon 2" && x.Manager.Name == "User M"))
            {
                context.Add(new HairSalonManager()
                {
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 2").First().HairSalonId,
                    ManagerId = context.Managers.Where(x => x.Name == "User M").First().ApplicationUserId
                });
            }

            if (!context.HairSalonManagers.Any(x => x.HairSalon.Name == "Hair Salon 1" && x.Manager.Name == "User M2"))
            {
                context.Add(new HairSalonManager()
                {
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 1").First().HairSalonId,
                    ManagerId = context.Managers.Where(x => x.Name == "User M2").First().ApplicationUserId
                });
            }

            if (!context.HairSalonManagers.Any(x => x.HairSalon.Name == "Hair Salon 2" && x.Manager.Name == "Manager Employee 1"))
            {
                context.Add(new HairSalonManager()
                {
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 2").First().HairSalonId,
                    ManagerId = context.Managers.Where(x => x.Name == "Manager Employee 1").First().ApplicationUserId
                });
            }

            context.SaveChanges();
        }

        private void ClientSeed(string salt, string hash)
        {
            if (!context.Clients.Any(x => x.Name == "Client A"))
            {
                var user = new Client()
                {
                    Name = "Client A",
                    Surname = "A Client",
                    Username = "aclient",
                    PasswordSalt = salt,
                    PasswordHash = hash,
                    Description = "test client"
                };

                context.Clients.Add(user);
            }

            var userRoles = new List<ApplicationUserRole>();
            for (int i = 0; i < 20; i++)
            {
                var newClient = new Client
                {
                    Name = Faker.Name.First(),
                    Surname = Faker.Name.Last(),
                    Username = Faker.Internet.UserName(),
                    PasswordSalt = salt,
                    PasswordHash = hash,
                    Description = Faker.Lorem.Paragraph()
                };

                context.Clients.Add(newClient);

                context.SaveChanges();

                userRoles.Add(new ApplicationUserRole
                {
                    ApplicationUserId = context.Clients.OrderBy(x => x.ApplicationUserId)
                        .Last()
                        .ApplicationUserId,
                    //TODO: should roles be referenced through an enum so I don't have to look up 
                    //the roleid when I want to assign it in code?
                    RoleId = context.Roles.Where(x => x.Name == "Client").Single().RoleId
                });
                
            }

            context.ApplicationUserRoles.AddRange(userRoles);

            context.SaveChanges();
        }

        private void ManagerSeed(string salt, string hash)
        {
            if (!context.Managers.Any(x => x.Name == "User M"))
            {
                var user = new Manager()
                {
                    Name = "User M",
                    Surname = "M User",
                    Username = "muser",
                    PasswordSalt = salt,
                    PasswordHash = hash,
                    Description = "First manager"
                };

                context.Managers.Add(user);
            }

            if (!context.Managers.Any(x => x.Name == "User M2"))
            {
                var user = new Manager()
                {
                    Name = "User M2",
                    Surname = "M2 User",
                    Username = "m2user",
                    PasswordSalt = salt,
                    PasswordHash = hash,
                    Description = "Second manager"
                };

                context.Managers.Add(user);
            }

            if (!context.Managers.Any(x => x.Name == "Manager Employee 1"))
            {
                context.Managers.Add(new ManagerEmployee()
                {
                    Name = "Manager Employee 1",
                    Surname = "Manager Employee 1",
                    Username = "me1user",
                    PasswordSalt = salt,
                    PasswordHash = hash,
                    Description = "The best manager employee there is!"
                });
            }

            context.SaveChanges();
        }

        private void RoleSeed()
        {
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

            context.SaveChanges();
        }

        private void HairSalonHairTypeSeed()
        {
            if (!context.HairSalonHairSalonTypes.Any(x => x.HairSalon.Name == "Hair Salon 1" && x.HairSalonType.Name == "Ženski"))
            {
                context.Add(new HairSalonHairSalonType()
                {
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 1").First().HairSalonId,
                    HairSalonTypeId = context.HairSalonTypes.Where(x => x.Name == "Ženski").First().HairSalonTypeId
                });
            }

            if (!context.HairSalonHairSalonTypes.Any(x => x.HairSalon.Name == "Hair Salon 2" && x.HairSalonType.Name == "Muški"))
            {
                context.Add(new HairSalonHairSalonType()
                {
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 2").First().HairSalonId,
                    HairSalonTypeId = context.HairSalonTypes.Where(x => x.Name == "Muški").First().HairSalonTypeId
                });
            }

            if (!context.HairSalonHairSalonTypes.Any(x => x.HairSalon.Name == "Hair Salon 2" && x.HairSalonType.Name == "Ženski"))
            {
                context.Add(new HairSalonHairSalonType()
                {
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 2").First().HairSalonId,
                    HairSalonTypeId = context.HairSalonTypes.Where(x => x.Name == "Ženski").First().HairSalonTypeId
                });
            }

            context.SaveChanges();
        }

        private void HairDresserSeed(string salt, string hash)
        {
            if (!context.HairDressers.Any(x => x.Name == "Hair Dresser 1"))
            {
                context.HairDressers.Add(new HairDresser()
                {
                    Name = "Hair Dresser 1",
                    Surname = "The First",
                    Description = "The best in town!",
                    PasswordSalt = salt,
                    PasswordHash = hash,
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 1").First().HairSalonId
                });
            }

            if (!context.HairDressers.Any(x => x.Name == "Hair Dresser 2"))
            {
                context.HairDressers.Add(new HairDresser()
                {
                    Name = "Hair Dresser 2",
                    Surname = "The Second",
                    Description = "The second best in town!",
                    PasswordSalt = salt,
                    PasswordHash = hash,
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 2").First().HairSalonId
                });
            }

            context.SaveChanges();
        }

        private void PictureSeed()
        {
            if (!context.Pictures.Any(x => x.Path == Path.Combine(_hostEnvironment.ContentRootPath + "Images/" + "SlikaA")))
            {
                context.Pictures.Add(new Picture() { Path = Path.Combine(_hostEnvironment.ContentRootPath + "Images/" + "SlikaA") });
            }

            if (!context.Pictures.Any(x => x.Path == Path.Combine(_hostEnvironment.ContentRootPath + "Images/" + "SlikaB")))
            {
                context.Pictures.Add(new Picture() { Path = Path.Combine(_hostEnvironment.ContentRootPath + "Images/" + "SlikaB") });
            }

            if (!context.Pictures.Any(x => x.Path == Path.Combine(_hostEnvironment.ContentRootPath + "Images/" + "SlikaC")))
            {
                context.Pictures.Add(new Picture() { Path = Path.Combine(_hostEnvironment.ContentRootPath + "Images/" + "SlikaC") });
            }

            context.SaveChanges();
        }

        private void HairSalonTypeSeed()
        {
            if (!context.HairSalonTypes.Any(x => x.Name == "Ženski"))
            {
                context.HairSalonTypes.Add(new HairSalonType() { Name = "Ženski" });
            }

            if (!context.HairSalonTypes.Any(x => x.Name == "Muški"))
            {
                context.HairSalonTypes.Add(new HairSalonType() { Name = "Muški" });
            }

            context.SaveChanges();
        }

        private void HairSalonSeed()
        {
            if (!context.HairSalons.Any(x => x.Name == "Hair Salon 1" && x.City.Name == "City 1"))
            {
                context.HairSalons.Add(new HairSalon()
                {
                    Name = "Hair Salon 1",
                    Address = "Mejdandžik 8",
                    Description = "Pravo dobar frizerski.",
                    CityId = context.Cities.Where(x => x.Name == "City 1").FirstOrDefault().CityId
                });
            }

            if (!context.HairSalons.Any(x => x.Name == "Hair Salon 2" && x.City.Name == "City 2"))
            {
                context.HairSalons.Add(new HairSalon()
                {
                    Name = "Hair Salon 2",
                    Address = "Maršala Tita 21",
                    Description = "Pravo dobar frizerski salon za muškarce i žene.",
                    CityId = context.Cities.Where(x => x.Name == "City 2").FirstOrDefault().CityId
                });
            }

            context.SaveChanges();

            var fakeSalons = new List<HairSalon>();
            for (int i = 0; i < 25; i++)
            {
                fakeSalons.Add(new HairSalon
                {
                    Name = Faker.Company.Name(),
                    Description = Faker.Company.CatchPhrase(),
                    Address = Faker.Address.StreetAddress(),
                    CityId = context.Cities.FirstOrDefault().CityId
                });
            }

            context.AddRange(fakeSalons);

            context.SaveChanges();
        }

        private void CitySeed()
        {
            if (!context.Cities.Any(x => x.Name == "City 1"))
            {
                context.Cities.Add(new City() { Name = "City 1" });
            }

            if (!context.Cities.Any(x => x.Name == "City 2"))
            {
                context.Cities.Add(new City() { Name = "City 2" });
            }

            if (!context.Cities.Any(x => x.Name == "City 3"))
            {
                context.Cities.Add(new City() { Name = "City 3" });
            }

            context.SaveChanges();
        }
    }
}
