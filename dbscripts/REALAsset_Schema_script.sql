USE [REALAsset]
GO
/****** Object:  User [real]    Script Date: 10/31/2020 10:11:19 AM ******/
CREATE USER [real] FOR LOGIN [real] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [real]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/31/2020 10:11:19 AM ******/
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
/****** Object:  Table [dbo].[FeePayment]    Script Date: 10/31/2020 10:11:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeePayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[ManagementContractId] [int] NOT NULL,
	[ScheduledPaymentAmt] [decimal](18, 0) NOT NULL,
	[ActualPaymentAmt] [decimal](18, 0) NOT NULL,
	[PayMethod] [nvarchar](max) NOT NULL,
	[MangementFeeType] [nvarchar](max) NOT NULL,
	[PaymentDueDate] [datetime2](7) NOT NULL,
	[PaymentReceivedDate] [datetime2](7) NOT NULL,
	[Balance] [decimal](18, 0) NULL,
	[IsOnTime] [bit] NOT NULL,
	[InChargeOwnerId] [int] NOT NULL,
	[Note] [nvarchar](450) NULL,
	[FeeForMonth] [nvarchar](max) NULL,
	[FeeForYear] [nvarchar](max) NULL,
 CONSTRAINT [PK_FeePayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManagementContract]    Script Date: 10/31/2020 10:11:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagementContract](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[ManagementContractTitle] [nvarchar](max) NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[PlacementFeeScale] [nvarchar](max) NULL,
	[ManagementFeeScale] [nvarchar](max) NULL,
	[ContractSignDate] [datetime2](7) NOT NULL,
	[PropertyId] [int] NOT NULL,
	[ManagementContractDocUrl] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Type] [nvarchar](50) NULL,
	[Contract] [nvarchar](max) NULL,
	[SolicitingOnly] [bit] NOT NULL,
 CONSTRAINT [PK_ManagementContract] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OwnerAddress]    Script Date: 10/31/2020 10:11:19 AM ******/
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
	[PropertyOwnerId] [int] NOT NULL,
 CONSTRAINT [PK_OwnerAddress] PRIMARY KEY CLUSTERED 
(
	[PropertyOwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OwnerProperty]    Script Date: 10/31/2020 10:11:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OwnerProperty](
	[PropertyId] [int] NOT NULL,
	[PropertyOwnerId] [int] NOT NULL,
 CONSTRAINT [PK_OwnerProperty] PRIMARY KEY CLUSTERED 
(
	[PropertyId] ASC,
	[PropertyOwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property]    Script Date: 10/31/2020 10:11:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyName] [nvarchar](50) NOT NULL,
	[PropertyDesc] [nvarchar](250) NULL,
	[StrataCouncilId] [int] NULL,
	[PropertyLogoImgUrl] [nvarchar](100) NULL,
	[PropertyVideoUrl] [nvarchar](100) NULL,
	[PropertyBuildYear] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsShared] [bit] NOT NULL,
	[IsBasementSuite] [bit] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[PropertyManagerUserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyAddress]    Script Date: 10/31/2020 10:11:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyAddress](
	[PropertySuiteNumber] [nvarchar](max) NULL,
	[PropertyNumber] [nvarchar](max) NULL,
	[PropertyStreet] [nvarchar](max) NULL,
	[PropertyCity] [nvarchar](max) NULL,
	[PropertyStateProvince] [nvarchar](max) NULL,
	[PropertyCountry] [nvarchar](max) NULL,
	[PropertyZipPostCode] [nvarchar](max) NULL,
	[GpslongitudeValue] [nvarchar](max) NULL,
	[GpslatitudeValue] [nvarchar](max) NULL,
	[PropertyId] [int] NOT NULL,
 CONSTRAINT [PK_PropertyAddress] PRIMARY KEY CLUSTERED 
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyFacility]    Script Date: 10/31/2020 10:11:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyFacility](
	[Stove] [bit] NULL,
	[Refrigerator] [bit] NULL,
	[Dishwasher] [bit] NULL,
	[AirConditioner] [bit] NOT NULL,
	[Laundry] [bit] NULL,
	[BlindsCurtain] [bit] NULL,
	[Furniture] [bit] NOT NULL,
	[Tvinternet] [bit] NOT NULL,
	[CommonFacility] [bit] NOT NULL,
	[SecuritySystem] [bit] NOT NULL,
	[UtilityIncluded] [bit] NOT NULL,
	[FireAlarmSystem] [bit] NULL,
	[Others] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[PropertyId] [int] NOT NULL,
 CONSTRAINT [PK_PropertyFacility] PRIMARY KEY CLUSTERED 
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyFeature]    Script Date: 10/31/2020 10:11:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyFeature](
	[NumberOfBedrooms] [int] NOT NULL,
	[NumberOfBathrooms] [int] NOT NULL,
	[NumberOfLayers] [int] NOT NULL,
	[NumberOfParking] [int] NOT NULL,
	[BasementAvailable] [bit] NOT NULL,
	[TotalLivingArea] [int] NOT NULL,
	[IsShared] [bit] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[PropertyId] [int] NOT NULL,
 CONSTRAINT [PK_PropertyFeature] PRIMARY KEY CLUSTERED 
(
	[PropertyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyImg]    Script Date: 10/31/2020 10:11:19 AM ******/
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
	[PropertyId] [int] NOT NULL,
 CONSTRAINT [PK_PropertyImg] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyOwner]    Script Date: 10/31/2020 10:11:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyOwner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[ContactEmail] [nvarchar](100) NOT NULL,
	[ContactTelephone1] [nvarchar](25) NOT NULL,
	[ContactTelephone2] [nvarchar](25) NULL,
	[OnlineAccess] [bit] NOT NULL,
	[UserAvartaImgUrl] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[RoleId] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_PropertyOwner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ManagementContract] ADD  DEFAULT ((0)) FOR [SolicitingOnly]
GO
ALTER TABLE [dbo].[Property] ADD  DEFAULT ((0)) FOR [StrataCouncilId]
GO
ALTER TABLE [dbo].[Property] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Property] ADD  DEFAULT (N'') FOR [Status]
GO
ALTER TABLE [dbo].[Property] ADD  DEFAULT (N'') FOR [Type]
GO
ALTER TABLE [dbo].[PropertyOwner] ADD  DEFAULT ('tba') FOR [UserName]
GO
ALTER TABLE [dbo].[PropertyOwner] ADD  DEFAULT ('default') FOR [UserAvartaImgUrl]
GO
ALTER TABLE [dbo].[PropertyOwner] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[FeePayment]  WITH CHECK ADD  CONSTRAINT [FK_FeePayment_ManagementContract] FOREIGN KEY([ManagementContractId])
REFERENCES [dbo].[ManagementContract] ([Id])
GO
ALTER TABLE [dbo].[FeePayment] CHECK CONSTRAINT [FK_FeePayment_ManagementContract]
GO
ALTER TABLE [dbo].[ManagementContract]  WITH CHECK ADD  CONSTRAINT [FK_ManagementContract_Property] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[ManagementContract] CHECK CONSTRAINT [FK_ManagementContract_Property]
GO
ALTER TABLE [dbo].[OwnerAddress]  WITH CHECK ADD  CONSTRAINT [FK_OwnerAddress_PropertyOwner_PropertyOwnerId] FOREIGN KEY([PropertyOwnerId])
REFERENCES [dbo].[PropertyOwner] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OwnerAddress] CHECK CONSTRAINT [FK_OwnerAddress_PropertyOwner_PropertyOwnerId]
GO
ALTER TABLE [dbo].[OwnerProperty]  WITH CHECK ADD  CONSTRAINT [FK_OwnerProperty_Property] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[OwnerProperty] CHECK CONSTRAINT [FK_OwnerProperty_Property]
GO
ALTER TABLE [dbo].[OwnerProperty]  WITH CHECK ADD  CONSTRAINT [FK_OwnerProperty_PropertyOwner] FOREIGN KEY([PropertyOwnerId])
REFERENCES [dbo].[PropertyOwner] ([Id])
GO
ALTER TABLE [dbo].[OwnerProperty] CHECK CONSTRAINT [FK_OwnerProperty_PropertyOwner]
GO
ALTER TABLE [dbo].[PropertyAddress]  WITH CHECK ADD  CONSTRAINT [FK_PropertyAddress_Property_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyAddress] CHECK CONSTRAINT [FK_PropertyAddress_Property_PropertyId]
GO
ALTER TABLE [dbo].[PropertyFacility]  WITH CHECK ADD  CONSTRAINT [FK_PropertyFacility_Property_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyFacility] CHECK CONSTRAINT [FK_PropertyFacility_Property_PropertyId]
GO
ALTER TABLE [dbo].[PropertyFeature]  WITH CHECK ADD  CONSTRAINT [FK_PropertyFeature_Property_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyFeature] CHECK CONSTRAINT [FK_PropertyFeature_Property_PropertyId]
GO
ALTER TABLE [dbo].[PropertyImg]  WITH CHECK ADD  CONSTRAINT [FK_PropertyImg_Property_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertyImg] CHECK CONSTRAINT [FK_PropertyImg_Property_PropertyId]
GO
