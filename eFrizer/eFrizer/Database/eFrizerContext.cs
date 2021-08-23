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
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost, 1434;Initial Catalog=eFrizer; user=sa; Password=QWEasd123!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("ApplicationUser");
            });

            modelBuilder.Entity<ApplicationUserRole>(entity =>
            {
                entity.HasKey(e => new { e.ApplicationUserId, e.RoleId })
                    .HasName("PK_applicationuser_role");

                entity.ToTable("ApplicationUser_Role");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.ApplicationUserRoles)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_93");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ApplicationUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_97");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HairDresser>(entity =>
            {
                entity.ToTable("HairDresser");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.HairSalon)
                    .WithMany(p => p.HairDressers)
                    .HasForeignKey(d => d.HairSalonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_73");
            });

            modelBuilder.Entity<HairSalon>(entity =>
            {
                entity.ToTable("HairSalon");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HairSalonCity>(entity =>
            {
                entity.HasKey(e => new { e.HairSalonId, e.CityId })
                    .HasName("PK_table_13");

                entity.ToTable("HairSalon_City");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.HairSalonCities)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_32");

                entity.HasOne(d => d.HairSalon)
                    .WithMany(p => p.HairSalonCities)
                    .HasForeignKey(d => d.HairSalonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_22");
            });

            modelBuilder.Entity<HairSalonHairSalonType>(entity =>
            {
                entity.HasKey(e => new { e.HairSalonId, e.HairSalonTypeId })
                    .HasName("PK_hairsalon_hairsalontype");

                entity.ToTable("HairSalon_HairSalonType");

                entity.Property(e => e.HairSalonTypeId).HasColumnName("HairSalonTypeID");

                entity.HasOne(d => d.HairSalon)
                    .WithMany(p => p.HairSalonHairSalonTypes)
                    .HasForeignKey(d => d.HairSalonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_111");

                entity.HasOne(d => d.HairSalonType)
                    .WithMany(p => p.HairSalonHairSalonTypes)
                    .HasForeignKey(d => d.HairSalonTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_115");
            });

            modelBuilder.Entity<HairSalonPicture>(entity =>
            {
                entity.HasKey(e => new { e.PictureId, e.HairSalonId })
                    .HasName("PK_hairsalon_picture");

                entity.ToTable("HairSalon_Picture");

                entity.HasOne(d => d.HairSalon)
                    .WithMany(p => p.HairSalonPictures)
                    .HasForeignKey(d => d.HairSalonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_56");

                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.HairSalonPictures)
                    .HasForeignKey(d => d.PictureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_48");
            });

            modelBuilder.Entity<HairSalonService>(entity =>
            {
                entity.HasKey(e => new { e.ServicesId, e.HairSalonId })
                    .HasName("PK_hairsalon_services");

                entity.ToTable("HairSalon_Services");

                entity.HasOne(d => d.HairSalon)
                    .WithMany(p => p.HairSalonServices)
                    .HasForeignKey(d => d.HairSalonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_67");

                entity.HasOne(d => d.Services)
                    .WithMany(p => p.HairSalonServices)
                    .HasForeignKey(d => d.ServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_63");
            });

            modelBuilder.Entity<HairSalonType>(entity =>
            {
                entity.ToTable("HairSalonType");

                entity.Property(e => e.HairSalonTypeId).HasColumnName("HairSalonTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.ToTable("Picture");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_86");

                entity.HasOne(d => d.HairDresser)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.HairDresserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_81");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_105");

                entity.HasOne(d => d.HairSalon)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.HairSalonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_102");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.ServicesId)
                    .HasName("PK_services");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
