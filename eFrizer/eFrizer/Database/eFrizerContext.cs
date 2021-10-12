using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace eFrizer.Database
{
    public partial class eFrizerContext : DbContext
    {
        public eFrizerContext()
        {
        }

        public eFrizerContext(DbContextOptions<eFrizerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<HairDresser> HairDressers { get; set; }
        public virtual DbSet<HairSalon> HairSalons { get; set; }
        public virtual DbSet<HairSalonCity> HairSalonCities { get; set; }
        public virtual DbSet<HairSalonHairSalonType> HairSalonHairSalonTypes { get; set; }
        public virtual DbSet<HairSalonPicture> HairSalonPictures { get; set; }
        public virtual DbSet<HairSalonService> HairSalonServices { get; set; }
        public virtual DbSet<HairSalonType> HairSalonTypes { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserRole>(entity =>
            {
                entity.HasKey(k => new { k.ApplicationUserId, k.RoleId })
                    .HasName("PK_applicationuser_role");
            });

            modelBuilder.Entity<HairSalonCity>(entity =>
            {
                entity.HasKey(k => new { k.HairSalonId, k.CityId })
                    .HasName("PK_hairsalon_city");
            });

            modelBuilder.Entity<HairSalonHairSalonType>(entity =>
            {
                entity.HasKey(k => new { k.HairSalonId, k.HairSalonTypeId })
                    .HasName("PK_hairsalon_hairsalontype");
            });

            modelBuilder.Entity<HairSalonPicture>(entity =>
            {
                entity.HasKey(k => new { k.HairSalonId, k.PictureId })
                    .HasName("PK_hairsalon_picture");
            });

            modelBuilder.Entity<HairSalonService>(entity =>
            {
                entity.HasKey(k => new { k.HairSalonId, k.ServiceId })
                    .HasName("PK_hairsalon_service");
            });

            modelBuilder.Entity<HairSalonHairDresser>(entity =>
            {
                entity.HasKey(k => new { k.HairSalonId, k.HairDresserId })
                    .HasName("PK_hairsalon_hairdresser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
