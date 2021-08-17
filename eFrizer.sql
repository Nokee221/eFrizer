create database eFrizer
go

use eFrizer



CREATE TABLE [HairSalon]
(
 [HairSalonId] int NOT NULL ,
 [Name]        nvarchar(50) NOT NULL ,
 [Description] nvarchar(150) NOT NULL ,
 [Address]     nvarchar(50) NOT NULL ,


 CONSTRAINT [PK_hairsalon] PRIMARY KEY CLUSTERED ([HairSalonId] ASC)
);
GO

CREATE TABLE [City]
(
 [CityId] int NOT NULL ,
 [Name]   nvarchar(50) NOT NULL ,


 CONSTRAINT [PK_city] PRIMARY KEY CLUSTERED ([CityId] ASC)
);
GO

CREATE TABLE [HairDresser]
(
 [HairDresserId] int NOT NULL ,
 [Name]          nvarchar(50) NOT NULL ,
 [HairSalonId]   int NOT NULL ,


 CONSTRAINT [PK_hairdresser] PRIMARY KEY CLUSTERED ([HairDresserId] ASC),
 CONSTRAINT [FK_73] FOREIGN KEY ([HairSalonId])  REFERENCES [HairSalon]([HairSalonId])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_74] ON [HairDresser] 
 (
  [HairSalonId] ASC
 )

GO


CREATE TABLE [HairSalon_City]
(
 [HairSalonId] int NOT NULL ,
 [CityId]      int NOT NULL ,


 CONSTRAINT [PK_table_13] PRIMARY KEY CLUSTERED ([HairSalonId] ASC, [CityId] ASC),
 CONSTRAINT [FK_22] FOREIGN KEY ([HairSalonId])  REFERENCES [HairSalon]([HairSalonId]),
 CONSTRAINT [FK_32] FOREIGN KEY ([CityId])  REFERENCES [City]([CityId])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_23] ON [HairSalon_City] 
 (
  [HairSalonId] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_33] ON [HairSalon_City] 
 (
  [CityId] ASC
 )

GO



CREATE TABLE [ApplicationUser]
(
 [ApplicationUserId] int NOT NULL ,


 CONSTRAINT [PK_applicationuser] PRIMARY KEY CLUSTERED ([ApplicationUserId] ASC)
);
GO


CREATE TABLE [Review]
(
 [ReviewId]          int NOT NULL ,
 [HairSalonId]       int NOT NULL ,
 [ApplicationUserId] int NOT NULL ,


 CONSTRAINT [PK_review] PRIMARY KEY CLUSTERED ([ReviewId] ASC),
 CONSTRAINT [FK_102] FOREIGN KEY ([HairSalonId])  REFERENCES [HairSalon]([HairSalonId]),
 CONSTRAINT [FK_105] FOREIGN KEY ([ApplicationUserId])  REFERENCES [ApplicationUser]([ApplicationUserId])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_103] ON [Review] 
 (
  [HairSalonId] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_106] ON [Review] 
 (
  [ApplicationUserId] ASC
 )

GO

CREATE TABLE [Role]
(
 [RoleId] int NOT NULL ,
 [Name]   nvarchar(50) NOT NULL ,


 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);
GO

CREATE TABLE [Services]
(
 [ServicesId]  int NOT NULL ,
 [Name]        nvarchar(50) NOT NULL ,
 [Description] nvarchar(150) NOT NULL ,


 CONSTRAINT [PK_services] PRIMARY KEY CLUSTERED ([ServicesId] ASC)
);
GO

CREATE TABLE [Reservation]
(
 [ReservationId]     int NOT NULL ,
 [HairDresserId]     int NOT NULL ,
 [ApplicationUserId] int NOT NULL ,
 [Time]              datetime NOT NULL ,


 CONSTRAINT [PK_reservation] PRIMARY KEY CLUSTERED ([ReservationId] ASC),
 CONSTRAINT [FK_81] FOREIGN KEY ([HairDresserId])  REFERENCES [HairDresser]([HairDresserId]),
 CONSTRAINT [FK_86] FOREIGN KEY ([ApplicationUserId])  REFERENCES [ApplicationUser]([ApplicationUserId])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_82] ON [Reservation] 
 (
  [HairDresserId] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_87] ON [Reservation] 
 (
  [ApplicationUserId] ASC
 )

GO


CREATE TABLE [Picture]
(
 [PictureId] int NOT NULL ,


 CONSTRAINT [PK_picture] PRIMARY KEY CLUSTERED ([PictureId] ASC)
);
GO


CREATE TABLE [HairSalonType]
(
 [HairSalonTypeID] int NOT NULL ,
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


CREATE NONCLUSTERED INDEX [fkIdx_64] ON [HairSalon_Services] 
 (
  [ServicesId] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_68] ON [HairSalon_Services] 
 (
  [HairSalonId] ASC
 )

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


CREATE NONCLUSTERED INDEX [fkIdx_49] ON [HairSalon_Picture] 
 (
  [PictureId] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_57] ON [HairSalon_Picture] 
 (
  [HairSalonId] ASC
 )

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


CREATE NONCLUSTERED INDEX [fkIdx_112] ON [HairSalon_HairSalonType] 
 (
  [HairSalonId] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_116] ON [HairSalon_HairSalonType] 
 (
  [HairSalonTypeID] ASC
 )

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


CREATE NONCLUSTERED INDEX [fkIdx_94] ON [ApplicationUser_Role] 
 (
  [ApplicationUserId] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_98] ON [ApplicationUser_Role] 
 (
  [RoleId] ASC
 )

GO

use master
drop database eFrizer