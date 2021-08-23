use master
drop database eFrizer

create database eFrizer
go

use eFrizer



CREATE TABLE [HairSalon]
(
 [HairSalonId] int NOT NULL IDENTITY(1,1) ,
 [Name]        nvarchar(50) NOT NULL ,
 [Description] nvarchar(150) NOT NULL ,
 [Address]     nvarchar(50) NOT NULL ,


 CONSTRAINT [PK_hairsalon] PRIMARY KEY ([HairSalonId])
);
GO

CREATE TABLE [City]
(
 [CityId] int NOT NULL IDENTITY(1,1),
 [Name]   nvarchar(50) NOT NULL ,


 CONSTRAINT [PK_city] PRIMARY KEY ([CityId])
);
GO

CREATE TABLE [HairDresser]
(
 [HairDresserId] int NOT NULL IDENTITY(1,1),
 [Name]          nvarchar(50) NOT NULL ,
 [HairSalonId]   int NOT NULL ,


 CONSTRAINT [PK_hairdresser] PRIMARY KEY ([HairDresserId]),
 CONSTRAINT [FK_73] FOREIGN KEY ([HairSalonId])  REFERENCES [HairSalon]([HairSalonId])
);
GO


CREATE TABLE [HairSalon_City]
(
 [HairSalonId] int NOT NULL ,
 [CityId]      int NOT NULL ,


 CONSTRAINT [PK_table_13] PRIMARY KEY ([HairSalonId], [CityId]),
 CONSTRAINT [FK_22] FOREIGN KEY ([HairSalonId])  REFERENCES [HairSalon]([HairSalonId]),
 CONSTRAINT [FK_32] FOREIGN KEY ([CityId])  REFERENCES [City]([CityId])
);
GO


CREATE TABLE [ApplicationUser]
(
 [ApplicationUserId] int NOT NULL IDENTITY(1,1),


 CONSTRAINT [PK_applicationuser] PRIMARY KEY ([ApplicationUserId])
);
GO


CREATE TABLE [Review]
(
 [ReviewId]          int NOT NULL IDENTITY(1,1),
 [HairSalonId]       int NOT NULL ,
 [ApplicationUserId] int NOT NULL ,


 CONSTRAINT [PK_review] PRIMARY KEY CLUSTERED ([ReviewId] ASC),
 CONSTRAINT [FK_102] FOREIGN KEY ([HairSalonId])  REFERENCES [HairSalon]([HairSalonId]),
 CONSTRAINT [FK_105] FOREIGN KEY ([ApplicationUserId])  REFERENCES [ApplicationUser]([ApplicationUserId])
);
GO


CREATE TABLE [Role]
(
 [RoleId] int NOT NULL IDENTITY(1,1),
 [Name]   nvarchar(50) NOT NULL ,


 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);
GO

CREATE TABLE [Services]
(
 [ServicesId]  int NOT NULL IDENTITY(1,1),
 [Name]        nvarchar(50) NOT NULL ,
 [Description] nvarchar(150) NOT NULL ,


 CONSTRAINT [PK_services] PRIMARY KEY CLUSTERED ([ServicesId] ASC)
);
GO

CREATE TABLE [Reservation]
(
 [ReservationId]     int NOT NULL IDENTITY(1,1),
 [HairDresserId]     int NOT NULL ,
 [ApplicationUserId] int NOT NULL ,
 [Time]              datetime NOT NULL ,


 CONSTRAINT [PK_reservation] PRIMARY KEY CLUSTERED ([ReservationId] ASC),
 CONSTRAINT [FK_81] FOREIGN KEY ([HairDresserId])  REFERENCES [HairDresser]([HairDresserId]),
 CONSTRAINT [FK_86] FOREIGN KEY ([ApplicationUserId])  REFERENCES [ApplicationUser]([ApplicationUserId])
);
GO


CREATE TABLE [Picture]
(
 [PictureId] int NOT NULL IDENTITY(1,1),


 CONSTRAINT [PK_picture] PRIMARY KEY CLUSTERED ([PictureId] ASC)
);
GO


CREATE TABLE [HairSalonType]
(
 [HairSalonTypeID] int NOT NULL IDENTITY(1,1),
 [Name]            nvarchar(50) NOT NULL ,


 CONSTRAINT [PK_hairsalontype] PRIMARY KEY CLUSTERED ([HairSalonTypeID] ASC)
);
GO


CREATE TABLE [HairSalon_Services]
(
 [ServicesId]  int NOT NULL ,
 [HairSalonId] int NOT NULL ,


 CONSTRAINT [PK_hairsalon_services] PRIMARY KEY CLUSTERED ([ServicesId] ASC, [HairSalonId] ASC),
 CONSTRAINT [FK_63] FOREIGN KEY ([ServicesId])  REFERENCES [Services]([ServicesId]),
 CONSTRAINT [FK_67] FOREIGN KEY ([HairSalonId])  REFERENCES [HairSalon]([HairSalonId])
);
GO


CREATE TABLE [HairSalon_Picture]
(
 [PictureId]   int NOT NULL ,
 [HairSalonId] int NOT NULL ,


 CONSTRAINT [PK_hairsalon_picture] PRIMARY KEY CLUSTERED ([PictureId] ASC, [HairSalonId] ASC),
 CONSTRAINT [FK_48] FOREIGN KEY ([PictureId])  REFERENCES [Picture]([PictureId]),
 CONSTRAINT [FK_56] FOREIGN KEY ([HairSalonId])  REFERENCES [HairSalon]([HairSalonId])
);
GO


CREATE TABLE [HairSalon_HairSalonType]
(
 [HairSalonId]     int NOT NULL ,
 [HairSalonTypeID] int NOT NULL ,


 CONSTRAINT [PK_hairsalon_hairsalontype] PRIMARY KEY CLUSTERED ([HairSalonId] ASC, [HairSalonTypeID] ASC),
 CONSTRAINT [FK_111] FOREIGN KEY ([HairSalonId])  REFERENCES [HairSalon]([HairSalonId]),
 CONSTRAINT [FK_115] FOREIGN KEY ([HairSalonTypeID])  REFERENCES [HairSalonType]([HairSalonTypeID])
);
GO


CREATE TABLE [ApplicationUser_Role]
(
 [ApplicationUserId] int NOT NULL ,
 [RoleId]            int NOT NULL ,


 CONSTRAINT [PK_applicationuser_role] PRIMARY KEY CLUSTERED ([ApplicationUserId] ASC, [RoleId] ASC),
 CONSTRAINT [FK_93] FOREIGN KEY ([ApplicationUserId])  REFERENCES [ApplicationUser]([ApplicationUserId]),
 CONSTRAINT [FK_97] FOREIGN KEY ([RoleId])  REFERENCES [Role]([RoleId])
);
GO