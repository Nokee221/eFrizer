﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eFrizer.Database;

namespace eFrizer.Migrations
{
    [DbContext(typeof(eFrizerContext))]
    [Migration("20210921193623_reservarion_add")]
    partial class reservarion_add
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eFrizer.Database.ApplicationUser", b =>
                {
                    b.Property<int>("ApplicationUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ApplicationUserId");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("eFrizer.Database.ApplicationUserRole", b =>
                {
                    b.Property<int>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationUserId", "RoleId")
                        .HasName("PK_applicationuser_role");

                    b.HasIndex("RoleId");

                    b.ToTable("ApplicationUser_Role");
                });

            modelBuilder.Entity("eFrizer.Database.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CityId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("eFrizer.Database.HairDresser", b =>
                {
                    b.Property<int>("HairDresserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HairSalonId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("HairDresserId");

                    b.HasIndex("HairSalonId");

                    b.ToTable("HairDresser");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalon", b =>
                {
                    b.Property<int>("HairSalonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("HairSalonId");

                    b.ToTable("HairSalon");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonCity", b =>
                {
                    b.Property<int>("HairSalonId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.HasKey("HairSalonId", "CityId")
                        .HasName("PK_table_13");

                    b.HasIndex("CityId");

                    b.ToTable("HairSalon_City");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonHairSalonType", b =>
                {
                    b.Property<int>("HairSalonId")
                        .HasColumnType("int");

                    b.Property<int>("HairSalonTypeId")
                        .HasColumnType("int")
                        .HasColumnName("HairSalonTypeID");

                    b.HasKey("HairSalonId", "HairSalonTypeId")
                        .HasName("PK_hairsalon_hairsalontype");

                    b.HasIndex("HairSalonTypeId");

                    b.ToTable("HairSalon_HairSalonType");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonPicture", b =>
                {
                    b.Property<int>("PictureId")
                        .HasColumnType("int");

                    b.Property<int>("HairSalonId")
                        .HasColumnType("int");

                    b.HasKey("PictureId", "HairSalonId")
                        .HasName("PK_hairsalon_picture");

                    b.HasIndex("HairSalonId");

                    b.ToTable("HairSalon_Picture");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonService", b =>
                {
                    b.Property<int>("ServicesId")
                        .HasColumnType("int");

                    b.Property<int>("HairSalonId")
                        .HasColumnType("int");

                    b.HasKey("ServicesId", "HairSalonId")
                        .HasName("PK_hairsalon_services");

                    b.HasIndex("HairSalonId");

                    b.ToTable("HairSalon_Services");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonType", b =>
                {
                    b.Property<int>("HairSalonTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("HairSalonTypeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("HairSalonTypeId");

                    b.ToTable("HairSalonType");
                });

            modelBuilder.Entity("eFrizer.Database.Picture", b =>
                {
                    b.Property<int>("PictureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("PictureId");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("eFrizer.Database.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime");

                    b.Property<int>("HairDresserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("ReservationId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("HairDresserId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("eFrizer.Database.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<int>("HairSalonId")
                        .HasColumnType("int");

                    b.Property<int>("StarRating")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("HairSalonId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("eFrizer.Database.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("eFrizer.Database.Service", b =>
                {
                    b.Property<int>("ServicesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ServicesId")
                        .HasName("PK_services");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("eFrizer.Database.ApplicationUserRole", b =>
                {
                    b.HasOne("eFrizer.Database.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("ApplicationUserId")
                        .HasConstraintName("FK_93")
                        .IsRequired();

                    b.HasOne("eFrizer.Database.Role", "Role")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_97")
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("eFrizer.Database.HairDresser", b =>
                {
                    b.HasOne("eFrizer.Database.HairSalon", "HairSalon")
                        .WithMany("HairDressers")
                        .HasForeignKey("HairSalonId")
                        .HasConstraintName("FK_73")
                        .IsRequired();

                    b.Navigation("HairSalon");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonCity", b =>
                {
                    b.HasOne("eFrizer.Database.City", "City")
                        .WithMany("HairSalonCities")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_32")
                        .IsRequired();

                    b.HasOne("eFrizer.Database.HairSalon", "HairSalon")
                        .WithMany("HairSalonCities")
                        .HasForeignKey("HairSalonId")
                        .HasConstraintName("FK_22")
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("HairSalon");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonHairSalonType", b =>
                {
                    b.HasOne("eFrizer.Database.HairSalon", "HairSalon")
                        .WithMany("HairSalonHairSalonTypes")
                        .HasForeignKey("HairSalonId")
                        .HasConstraintName("FK_111")
                        .IsRequired();

                    b.HasOne("eFrizer.Database.HairSalonType", "HairSalonType")
                        .WithMany("HairSalonHairSalonTypes")
                        .HasForeignKey("HairSalonTypeId")
                        .HasConstraintName("FK_115")
                        .IsRequired();

                    b.Navigation("HairSalon");

                    b.Navigation("HairSalonType");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonPicture", b =>
                {
                    b.HasOne("eFrizer.Database.HairSalon", "HairSalon")
                        .WithMany("HairSalonPictures")
                        .HasForeignKey("HairSalonId")
                        .HasConstraintName("FK_56")
                        .IsRequired();

                    b.HasOne("eFrizer.Database.Picture", "Picture")
                        .WithMany("HairSalonPictures")
                        .HasForeignKey("PictureId")
                        .HasConstraintName("FK_48")
                        .IsRequired();

                    b.Navigation("HairSalon");

                    b.Navigation("Picture");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonService", b =>
                {
                    b.HasOne("eFrizer.Database.HairSalon", "HairSalon")
                        .WithMany("HairSalonServices")
                        .HasForeignKey("HairSalonId")
                        .HasConstraintName("FK_67")
                        .IsRequired();

                    b.HasOne("eFrizer.Database.Service", "Services")
                        .WithMany("HairSalonServices")
                        .HasForeignKey("ServicesId")
                        .HasConstraintName("FK_63")
                        .IsRequired();

                    b.Navigation("HairSalon");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("eFrizer.Database.Reservation", b =>
                {
                    b.HasOne("eFrizer.Database.ApplicationUser", "ApplicationUser")
                        .WithMany("Reservations")
                        .HasForeignKey("ApplicationUserId")
                        .HasConstraintName("FK_86")
                        .IsRequired();

                    b.HasOne("eFrizer.Database.HairDresser", "HairDresser")
                        .WithMany("Reservations")
                        .HasForeignKey("HairDresserId")
                        .HasConstraintName("FK_81")
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("HairDresser");
                });

            modelBuilder.Entity("eFrizer.Database.Review", b =>
                {
                    b.HasOne("eFrizer.Database.ApplicationUser", "ApplicationUser")
                        .WithMany("Reviews")
                        .HasForeignKey("ApplicationUserId")
                        .HasConstraintName("FK_105")
                        .IsRequired();

                    b.HasOne("eFrizer.Database.HairSalon", "HairSalon")
                        .WithMany("Reviews")
                        .HasForeignKey("HairSalonId")
                        .HasConstraintName("FK_102")
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("HairSalon");
                });

            modelBuilder.Entity("eFrizer.Database.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUserRoles");

                    b.Navigation("Reservations");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("eFrizer.Database.City", b =>
                {
                    b.Navigation("HairSalonCities");
                });

            modelBuilder.Entity("eFrizer.Database.HairDresser", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalon", b =>
                {
                    b.Navigation("HairDressers");

                    b.Navigation("HairSalonCities");

                    b.Navigation("HairSalonHairSalonTypes");

                    b.Navigation("HairSalonPictures");

                    b.Navigation("HairSalonServices");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("eFrizer.Database.HairSalonType", b =>
                {
                    b.Navigation("HairSalonHairSalonTypes");
                });

            modelBuilder.Entity("eFrizer.Database.Picture", b =>
                {
                    b.Navigation("HairSalonPictures");
                });

            modelBuilder.Entity("eFrizer.Database.Role", b =>
                {
                    b.Navigation("ApplicationUserRoles");
                });

            modelBuilder.Entity("eFrizer.Database.Service", b =>
                {
                    b.Navigation("HairSalonServices");
                });
#pragma warning restore 612, 618
        }
    }
}
