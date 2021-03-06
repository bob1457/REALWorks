USE [REALMarketing]
GO
/****** Object:  User [real]    Script Date: 10/31/2020 10:14:22 AM ******/
CREATE USER [real] FOR LOGIN [real] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [real]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/31/2020 10:14:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 10/31/2020 10:14:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[StreetNum] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[StateProvince] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[ZipPostCode] [nvarchar](max) NULL,
	[RentalPropertyId] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[RentalPropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeoLocation]    Script Date: 10/31/2020 10:14:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeoLocation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NULL,
	[Modified] [datetime2](7) NULL,
	[City] [nvarchar](350) NOT NULL,
	[StateProv] [nvarchar](max) NULL,
	[Region] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
 CONSTRAINT [PK_GeoLocation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListingContact]    Script Date: 10/31/2020 10:14:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListingContact](
	[ContactName] [nvarchar](50) NOT NULL,
	[ContactTel] [nvarchar](50) NOT NULL,
	[ContactEmail] [nvarchar](50) NOT NULL,
	[ContactSMS] [nvarchar](50) NULL,
	[ContactOthers] [nvarchar](50) NULL,
	[PropertyListingId] [int] NOT NULL,
 CONSTRAINT [PK_ListingContact] PRIMARY KEY CLUSTERED 
(
	[PropertyListingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OpenHouse]    Script Date: 10/31/2020 10:14:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpenHouse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[RentalPropertyId] [int] NOT NULL,
	[OpenhouseDate] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[StartTime] [nvarchar](50) NOT NULL,
	[EndTime] [nvarchar](50) NOT NULL,
	[Notes] [nvarchar](350) NULL,
 CONSTRAINT [PK_OpenHouse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OpenHouseViewer]    Script Date: 10/31/2020 10:14:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpenHouseViewer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[OpenHouseId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[ContactTel] [nvarchar](50) NULL,
	[ContactEmail] [nvarchar](50) NULL,
	[ContactSMS] [nvarchar](50) NULL,
	[ContactOthers] [nvarchar](50) NULL,
	[NumberOfPeople] [int] NULL,
	[ContactType] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_OpenHouseViewer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OwnerAddress]    Script Date: 10/31/2020 10:14:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OwnerAddress](
	[StreetNumber] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[StateProvince] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[ZipPostCode] [nvarchar](max) NULL,
	[RentalPropertyOwnerId] [int] NOT NULL,
 CONSTRAINT [PK_OwnerAddress] PRIMARY KEY CLUSTERED 
(
	[RentalPropertyOwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyImg]    Script Date: 10/31/2020 10:14:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyImg](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[PropertyImgTitle] [nvarchar](max) NULL,
	[PropertyImgUrl] [nvarchar](max) NULL,
	[RentalPropertyId] [int] NOT NULL,
 CONSTRAINT [PK_PropertyImg] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyListing]    Script Date: 10/31/2020 10:14:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyListing](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[RentalPropertyId] [int] NOT NULL,
	[ListingDesc] [nvarchar](max) NOT NULL,
	[MonthlyRent] [decimal](18, 2) NOT NULL,
	[Note] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_PropertyListing] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalApplicant]    Script Date: 10/31/2020 10:14:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalApplicant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[ContactTel] [nvarchar](50) NOT NULL,
	[ContactEmail] [nvarchar](50) NOT NULL,
	[ContactSMS] [nvarchar](50) NULL,
	[ContactOthers] [nvarchar](50) NULL,
	[AnnualIncome] [int] NULL,
	[NumberOfOccupant] [int] NOT NULL,
	[WithChildren] [bit] NULL,
	[Status] [nvarchar](max) NOT NULL,
	[CreditRating] [nvarchar](5) NULL,
	[EmpoyedStatus] [nvarchar](20) NULL,
	[RentalApplicationId] [int] NOT NULL,
	[ReasonToMove] [nvarchar](max) NULL,
	[WithCoApplicant] [bit] NOT NULL,
 CONSTRAINT [PK_RentalApplicant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalApplicantScoreCard]    Script Date: 10/31/2020 10:14:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalApplicantScoreCard](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[RentalApplicantId] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[CreditCheckScore] [int] NOT NULL,
	[IncomeCheckScore] [int] NOT NULL,
	[OtherCheckScore] [int] NOT NULL,
	[ReferenceCheckScore] [int] NOT NULL,
 CONSTRAINT [PK_RentalApplicantScoreCard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalApplication]    Script Date: 10/31/2020 10:14:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalApplication](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[RentalPropertyId] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_RentalApplication] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalProperty]    Script Date: 10/31/2020 10:14:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalProperty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[OriginalId] [int] NOT NULL,
	[PropertyName] [nvarchar](50) NOT NULL,
	[PropertyType] [nvarchar](50) NOT NULL,
	[PropertyBuildYear] [int] NOT NULL,
	[IsShared] [bit] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[IsBasementSuite] [bit] NOT NULL,
	[NumberOfBedrooms] [int] NOT NULL,
	[NumberOfBathrooms] [int] NOT NULL,
	[NumberOfLayers] [int] NOT NULL,
	[NumberOfParking] [int] NOT NULL,
	[TotalLivingArea] [int] NOT NULL,
	[Notes] [nvarchar](450) NULL,
	[PmUserName] [nvarchar](max) NULL,
	[OwnerId] [int] NULL,
	[GeoLocationId] [int] NULL,
 CONSTRAINT [PK_RentalProperty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalPropertyOwner]    Script Date: 10/31/2020 10:14:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalPropertyOwner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[ContactEmail] [nvarchar](50) NULL,
	[ContactTelephone] [nvarchar](50) NULL,
	[ContactOther] [nvarchar](50) NULL,
	[RentalPropertyId] [int] NOT NULL,
 CONSTRAINT [PK_RentalPropertyOwner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalReference]    Script Date: 10/31/2020 10:14:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalReference](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[RentalApplicatId] [int] NOT NULL,
	[ContactName] [nvarchar](50) NOT NULL,
	[ContactTel] [nvarchar](50) NOT NULL,
	[ContactEmail] [nvarchar](50) NOT NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_RentalReference] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OpenHouseViewer] ADD  DEFAULT (N'') FOR [ContactType]
GO
ALTER TABLE [dbo].[PropertyListing] ADD  DEFAULT ((0.0)) FOR [MonthlyRent]
GO
ALTER TABLE [dbo].[PropertyListing] ADD  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[RentalApplicant] ADD  DEFAULT ((0)) FOR [WithCoApplicant]
GO
ALTER TABLE [dbo].[RentalApplicantScoreCard] ADD  DEFAULT ((0)) FOR [CreditCheckScore]
GO
ALTER TABLE [dbo].[RentalApplicantScoreCard] ADD  DEFAULT ((0)) FOR [IncomeCheckScore]
GO
ALTER TABLE [dbo].[RentalApplicantScoreCard] ADD  DEFAULT ((0)) FOR [OtherCheckScore]
GO
ALTER TABLE [dbo].[RentalApplicantScoreCard] ADD  DEFAULT ((0)) FOR [ReferenceCheckScore]
GO
ALTER TABLE [dbo].[RentalApplication] ADD  DEFAULT (N'') FOR [Status]
GO
ALTER TABLE [dbo].[RentalProperty] ADD  CONSTRAINT [DF__RentalPro__GeoLo__4D94879B]  DEFAULT ((0)) FOR [GeoLocationId]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_RentalProperty_RentalPropertyId] FOREIGN KEY([RentalPropertyId])
REFERENCES [dbo].[RentalProperty] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_RentalProperty_RentalPropertyId]
GO
ALTER TABLE [dbo].[ListingContact]  WITH CHECK ADD  CONSTRAINT [FK_ListingContact_PropertyListing_PropertyListingId] FOREIGN KEY([PropertyListingId])
REFERENCES [dbo].[PropertyListing] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ListingContact] CHECK CONSTRAINT [FK_ListingContact_PropertyListing_PropertyListingId]
GO
ALTER TABLE [dbo].[OpenHouse]  WITH CHECK ADD  CONSTRAINT [FK_OpenHouse_RentalProperty] FOREIGN KEY([RentalPropertyId])
REFERENCES [dbo].[RentalProperty] ([Id])
GO
ALTER TABLE [dbo].[OpenHouse] CHECK CONSTRAINT [FK_OpenHouse_RentalProperty]
GO
ALTER TABLE [dbo].[OpenHouseViewer]  WITH CHECK ADD  CONSTRAINT [FK_OpenHouseViewer_OpenHouse] FOREIGN KEY([OpenHouseId])
REFERENCES [dbo].[OpenHouse] ([Id])
GO
ALTER TABLE [dbo].[OpenHouseViewer] CHECK CONSTRAINT [FK_OpenHouseViewer_OpenHouse]
GO
ALTER TABLE [dbo].[OwnerAddress]  WITH CHECK ADD  CONSTRAINT [FK_OwnerAddress_RentalPropertyOwner_RentalPropertyOwnerId] FOREIGN KEY([RentalPropertyOwnerId])
REFERENCES [dbo].[RentalPropertyOwner] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OwnerAddress] CHECK CONSTRAINT [FK_OwnerAddress_RentalPropertyOwner_RentalPropertyOwnerId]
GO
ALTER TABLE [dbo].[PropertyImg]  WITH CHECK ADD  CONSTRAINT [FK_PropertyImg_RentalProperty] FOREIGN KEY([RentalPropertyId])
REFERENCES [dbo].[RentalProperty] ([Id])
GO
ALTER TABLE [dbo].[PropertyImg] CHECK CONSTRAINT [FK_PropertyImg_RentalProperty]
GO
ALTER TABLE [dbo].[PropertyListing]  WITH CHECK ADD  CONSTRAINT [FK_PropertyListing_RentalProperty] FOREIGN KEY([RentalPropertyId])
REFERENCES [dbo].[RentalProperty] ([Id])
GO
ALTER TABLE [dbo].[PropertyListing] CHECK CONSTRAINT [FK_PropertyListing_RentalProperty]
GO
ALTER TABLE [dbo].[RentalApplicant]  WITH CHECK ADD  CONSTRAINT [FK_RentalApplicant_RentalApplication_RentalApplicationId] FOREIGN KEY([RentalApplicationId])
REFERENCES [dbo].[RentalApplication] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RentalApplicant] CHECK CONSTRAINT [FK_RentalApplicant_RentalApplication_RentalApplicationId]
GO
ALTER TABLE [dbo].[RentalApplicantScoreCard]  WITH CHECK ADD  CONSTRAINT [FK_RentalApplicantScoreCard_RentalApplicant_RentalApplicantId] FOREIGN KEY([RentalApplicantId])
REFERENCES [dbo].[RentalApplicant] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RentalApplicantScoreCard] CHECK CONSTRAINT [FK_RentalApplicantScoreCard_RentalApplicant_RentalApplicantId]
GO
ALTER TABLE [dbo].[RentalApplication]  WITH CHECK ADD  CONSTRAINT [FK_RentalApplication_RentalProperty] FOREIGN KEY([RentalPropertyId])
REFERENCES [dbo].[RentalProperty] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RentalApplication] CHECK CONSTRAINT [FK_RentalApplication_RentalProperty]
GO
ALTER TABLE [dbo].[RentalPropertyOwner]  WITH CHECK ADD  CONSTRAINT [FK_PropertyOwner_RentalProperty] FOREIGN KEY([RentalPropertyId])
REFERENCES [dbo].[RentalProperty] ([Id])
GO
ALTER TABLE [dbo].[RentalPropertyOwner] CHECK CONSTRAINT [FK_PropertyOwner_RentalProperty]
GO
ALTER TABLE [dbo].[RentalReference]  WITH CHECK ADD  CONSTRAINT [FK_RentalReference_RentalApplicant] FOREIGN KEY([RentalApplicatId])
REFERENCES [dbo].[RentalApplicant] ([Id])
GO
ALTER TABLE [dbo].[RentalReference] CHECK CONSTRAINT [FK_RentalReference_RentalApplicant]
GO
