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
            ReservationSeed();
            LoyaltyBonusSeed();
            TextReviewSeed();

        }

        

        private void ReservationSeed()
        {
            if (!context.Reservations.Any(x => x.Client.Username == "aclient" &&
                                          x.HairDresser.Name == "Hair Dresser 2" &&
                                          x.HairSalonService.Service.Name == "Šišanje"))
            {
                var res = new Reservation()
                {
                    ClientId = context.Clients.Where(x => x.Username == "aclient").First().ApplicationUserId,
                    HairDresserId = context.HairDressers.Where(x => x.Name == "Hair Dresser 2").First().ApplicationUserId,
                    HairSalonServiceId = context.HairSalonServices.Where(x => x.Service.Name == "Šišanje").First().ServiceId,
                    From = DateTime.Parse("12/01/2022 15:00"),
                    To = DateTime.Parse("12/01/2022 15:30")
                };

                context.Reservations.Add(res);
                context.SaveChanges();
            }

            

            var fakeReservations = new List<Reservation>();
            var clients = context.Clients.OrderBy(x => x.ApplicationUserId).ToList();
            var hairDressers = context.HairDressers.ToList();
            var hairSalonServices = context.HairSalonServices.ToList();

            var uniqueDates = new List<Tuple<DateTime, DateTime>>();

            var openFrom = "08:00";
            var openUntil = "19:00";

            foreach (var client in clients)
            {
                foreach (var hairDresser in hairDressers)
                {
                    var services = hairSalonServices.Where(x => x.HairSalonId == hairDresser.HairSalonId).ToList();
                    foreach (var service in services)
                    {
                        bool isAvailable = true;
                        do
                        {
                            DateTime fakeDateTimeFrom, fakeDateTimeTo;
                            do
                            {
                                fakeDateTimeFrom = new Bogus.Faker().Date.Soon(10);
                                fakeDateTimeTo = fakeDateTimeFrom.AddMinutes(service.TimeMin);
                            }
                            while (
                                fakeDateTimeFrom.TimeOfDay < TimeSpan.Parse(openFrom) ||
                                fakeDateTimeFrom.TimeOfDay > TimeSpan.Parse(openUntil) ||
                                fakeDateTimeTo.TimeOfDay < TimeSpan.Parse(openFrom) ||
                                fakeDateTimeTo.TimeOfDay > TimeSpan.Parse(openUntil)
                            );


                            foreach (var item in uniqueDates)
                            {
                                isAvailable = true;
                                if (fakeDateTimeFrom < item.Item2 && fakeDateTimeTo > item.Item1)
                                {
                                    isAvailable = false;
                                    break;
                                }
                            }

                            if (isAvailable)
                            {
                                uniqueDates.Add(new Tuple<DateTime, DateTime>(fakeDateTimeFrom, fakeDateTimeTo));
                                context.Reservations.Add(new Reservation
                                {

                                    ClientId = client.ApplicationUserId,
                                    HairDresserId = hairDresser.ApplicationUserId,
                                    HairSalonServiceId = service.ServiceId,
                                    From = fakeDateTimeFrom,
                                    To = fakeDateTimeTo
                                });
                            } 
                        } while (isAvailable == false);
                        
                    }
                }
            }

            context.SaveChanges();

            foreach (var client in clients)
            {
                foreach (var hairDresser in hairDressers)
                {
                    var services = hairSalonServices.Where(x => x.HairSalonId == hairDresser.HairSalonId).ToList();
                    foreach (var service in services)
                    {
                        bool isAvailable = true;
                        do
                        {
                            DateTime fakeDateTimeFrom, fakeDateTimeTo;
                            do
                            {
                                fakeDateTimeFrom = new Bogus.Faker().Date.Recent(10);
                                fakeDateTimeTo = fakeDateTimeFrom.AddMinutes(service.TimeMin);
                            }
                            while (
                                fakeDateTimeFrom.TimeOfDay < TimeSpan.Parse(openFrom) ||
                                fakeDateTimeFrom.TimeOfDay > TimeSpan.Parse(openUntil) ||
                                fakeDateTimeTo.TimeOfDay < TimeSpan.Parse(openFrom) ||
                                fakeDateTimeTo.TimeOfDay > TimeSpan.Parse(openUntil)
                            );


                            foreach (var item in uniqueDates)
                            {
                                isAvailable = true;
                                if (fakeDateTimeFrom < item.Item2 && fakeDateTimeTo > item.Item1)
                                {
                                    isAvailable = false;
                                    break;
                                }
                            }

                            if (isAvailable)
                            {
                                uniqueDates.Add(new Tuple<DateTime, DateTime>(fakeDateTimeFrom, fakeDateTimeTo));
                                context.Reservations.Add(new Reservation
                                {

                                    ClientId = client.ApplicationUserId,
                                    HairDresserId = hairDresser.ApplicationUserId,
                                    HairSalonServiceId = service.ServiceId,
                                    From = fakeDateTimeFrom,
                                    To = fakeDateTimeTo
                                });
                            }
                        } while (isAvailable == false);
                    }
                }

            }

            context.SaveChanges();
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

        
        private void ReviewSeed()
        {
            if (!context.Reviews.Any(x => x.Client.Name == "Client A" && x.HairSalon.Name == "Hair Salon 1" ))
            {
                context.Reviews.Add(new Review()
                {
                    ClientId = context.Clients.Where(x => x.Name == "Client A").First().ApplicationUserId,
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 1").First().HairSalonId,
                    

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
                        
                    });
                }
            }

            context.AddRange(fakeReviews);

            context.SaveChanges();
        }

        private void TextReviewSeed()
        {
            if (!context.TextReviews.Any(x => x.Client.Name == "Client A" && x.HairSalon.Name == "Hair Salon 1"))
            {
                context.TextReviews.Add(new TextReview()
                {
                    ClientId = context.Clients.Where(x => x.Name == "Client A").First().ApplicationUserId,
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 1").First().HairSalonId,
                    Text = "Ekstra dobar salon sa dobrim cijenama",

                });
            }

            context.SaveChanges();

            var fakeReviews = new List<TextReview>();
            var clientsQuery = context.Clients.AsEnumerable();
            var clients = clientsQuery.OrderBy(x => x.ApplicationUserId).TakeLast(19).ToList();
            var hairSalonsQuery = context.HairSalons.AsEnumerable();
            var hairSalons = hairSalonsQuery.ToList();

            foreach (var client in clients)
            {
                foreach (var hairSalon in hairSalons)
                {
                    fakeReviews.Add(new TextReview
                    {
                        ClientId = client.ApplicationUserId,
                        HairSalonId = hairSalon.HairSalonId,
                        Text = Faker.Lorem.Paragraph()

                    });
                }
            }

            context.AddRange(fakeReviews);

            context.SaveChanges();
        }

        private void LoyaltyBonusSeed()
        {
            if (!context.HairSalonServiceLoyaltyBonuses.Any(x => x.Service.Service.Name == "Brijanje"))
            {
                context.HairSalonServiceLoyaltyBonuses.Add(new HairSalonServiceLoyaltyBonus()
                {
                    HairSalonServiceId = context.HairSalonServices.Where(x => x.Service.Name == "Brijanje").First().Id,
                    Discount = 15,
                    ActivatesOn = 5,
                    ExpiresIn = 30

                });

                context.SaveChanges();
            }

            if (!context.HairSalonServiceLoyaltyBonuses.Any(x => x.Service.Service.Name == "Farbanje"))
            {
                context.HairSalonServiceLoyaltyBonuses.Add(new HairSalonServiceLoyaltyBonus()
                {
                    HairSalonServiceId = context.HairSalonServices.Where(x => x.Service.Name == "Farbanje").First().Id,
                    Discount = 30,
                    ActivatesOn = 10,
                    ExpiresIn = 30

                });

                context.SaveChanges();
            }

            if (!context.HairSalonServiceLoyaltyBonuses.Any(x => x.Service.Service.Name == "Šišanje"))
            {
                context.HairSalonServiceLoyaltyBonuses.Add(new HairSalonServiceLoyaltyBonus()
                {
                    HairSalonServiceId = context.HairSalonServices.Where(x => x.Service.Name == "Šišanje").First().Id,
                    Discount = 15,
                    ActivatesOn = 5,
                    ExpiresIn = 30

                });

                context.SaveChanges();
            }
        }

        private void HairSalonServiceSeed()
        {
            if (!context.HairSalonServices.Any(x => x.HairSalon.Name == "Hair Salon 1" && x.Service.Name == "Šišanje"))
            {
                context.HairSalonServices.Add(new HairSalonService()
                {
                    ServiceId = context.Services.Where(x => x.Name == "Šišanje").First().ServiceId,
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 1").First().HairSalonId,
                    Description = "Muško šišanje",
                    Price = 10,
                    TimeMin = 30

                });
            }

            if (!context.HairSalonServices.Any(x => x.HairSalon.Name == "Hair Salon 2" && x.Service.Name == "Farbanje"))
            {
                context.HairSalonServices.Add(new HairSalonService()
                {
                    ServiceId = context.Services.Where(x => x.Name == "Farbanje").First().ServiceId,
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 2").First().HairSalonId,
                    Description = "Muško farbanje",
                    Price = 40,
                    TimeMin = 60

                });
            }

            if (!context.HairSalonServices.Any(x => x.HairSalon.Name == "Hair Salon 2" && x.Service.Name == "Brijanje"))
            {
                context.HairSalonServices.Add(new HairSalonService()
                {
                    ServiceId = context.Services.Where(x => x.Name == "Brijanje").First().ServiceId,
                    HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 2").First().HairSalonId,
                    Description = "Muško brijanje",
                    Price = 7,
                    TimeMin = 30

                });
            }

            
            context.SaveChanges();
        }



        private void ServiceSeed()
        {
            if (!context.Services.Any(x => x.Name == "Šišanje"))
            {
                context.Services.Add(new Service() { Name = "Šišanje", });
            }

            if (!context.Services.Any(x => x.Name == "Farbanje"))
            {
                context.Services.Add(new Service() { Name = "Farbanje",  });
            }

            if (!context.Services.Any(x => x.Name == "Brijanje"))
            {
                context.Services.Add(new Service() { Name = "Brijanje", });
            }

            context.SaveChanges();
        }

        private void HairSalonPictureSeed()
        {
            for (int i = 0; i < 5; i++)
            {
                if (!context.HairSalonPictures.Any(x => x.HairSalon.Name == "Hair Salon 1" && x.Picture.Path == _hostEnvironment.ContentRootPath + "Images/" + "Slika" + (i + 1) + ".jpg"))
                {
                    context.HairSalonPictures.Add(new HairSalonPicture()
                    {
                        HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 1").First().HairSalonId,
                        PictureId = context.Pictures.Where(x => x.Path == Path.Combine(_hostEnvironment.ContentRootPath + "Images/" + "Slika" + (i + 1) + ".jpg")).First().PictureId,
                    });
                }
            }

            for (int i = 5; i < 10; i++)
            {
                if (!context.HairSalonPictures.Any(x => x.HairSalon.Name == "Hair Salon 2" && x.Picture.Path == _hostEnvironment.ContentRootPath + "Images/" + "Slika" + (i + 1) + ".jpg"))
                {
                    context.HairSalonPictures.Add(new HairSalonPicture()
                    {
                        HairSalonId = context.HairSalons.Where(x => x.Name == "Hair Salon 2").First().HairSalonId,
                        PictureId = context.Pictures.Where(x => x.Path == Path.Combine(_hostEnvironment.ContentRootPath + "Images/" + "Slika" + (i + 1) + ".jpg")).First().PictureId,
                    });
                }
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

            if (!context.ApplicationUserRoles.Any(x => x.ApplicationUser.Name == "Manager Employee 1" && x.Role.Name == "Manager"))
            {
                var row = new ApplicationUserRole()
                {
                    ApplicationUserId = context.ApplicationUsers.Where(x => x.Name == "Manager Employee 1").First().ApplicationUserId,
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

            context.SaveChanges();

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
                    Username = "hairdresser1",
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
                    Username = "hairdresser2",
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
            for (int i = 0; i < 10; i++)
            {
                if (!context.Pictures.Any(x => x.Path == Path.Combine(_hostEnvironment.ContentRootPath + "Images/" + "Slika" + (i + 1) + ".jpg")))
                {
                    context.Pictures.Add(new Picture() { Path = Path.Combine(_hostEnvironment.ContentRootPath + "Images/" + "Slika" + (i + 1) + ".jpg") });
                }
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
