USE [REALLease]
GO
/****** Object:  User [real]    Script Date: 10/31/2020 10:13:50 AM ******/
CREATE USER [real] FOR LOGIN [real] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [real]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/31/2020 10:13:50 AM ******/
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
/****** Object:  Table [dbo].[Address]    Script Date: 10/31/2020 10:13:50 AM ******/
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
/****** Object:  Table [dbo].[Agent]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[LeaseId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[ContactEmial] [nvarchar](150) NOT NULL,
	[ContztTel] [nvarchar](150) NOT NULL,
	[ContactOthers] [nvarchar](250) NULL,
	[isPropertyManager] [bit] NOT NULL,
	[AddressStreetNumber] [nvarchar](50) NOT NULL,
	[AddressCity] [nvarchar](50) NOT NULL,
	[AddressStateProv] [nvarchar](50) NOT NULL,
	[AddressZipPostCode] [nvarchar](50) NOT NULL,
	[AddressCountry] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Agent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BasementCondition]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasementCondition](
	[PropertyInspectionId] [int] NOT NULL,
	[LightingB] [int] NOT NULL,
	[LightingE] [int] NOT NULL,
	[LightingCommentB] [nvarchar](max) NULL,
	[LightingCommentE] [nvarchar](max) NULL,
	[WindowsCoveringB] [int] NOT NULL,
	[WindowsCoveringE] [int] NOT NULL,
	[WindowsCoveringCommentB] [int] NOT NULL,
	[WindowsCoveringCommentE] [int] NOT NULL,
	[ElectricalOutletsB] [int] NOT NULL,
	[ElectricalOutletsE] [int] NOT NULL,
	[ElectricalOutletsCommentB] [nvarchar](max) NULL,
	[ElectricalOutletsCommentE] [nvarchar](max) NULL,
	[StairwellB] [int] NOT NULL,
	[StairwellE] [int] NOT NULL,
	[StairwellCommentB] [nvarchar](max) NULL,
	[StairwellCommentE] [nvarchar](max) NULL,
	[WallsAndFloorCarpetB] [int] NOT NULL,
	[WallsAndFloorCarpetE] [int] NOT NULL,
	[WallsAndFloorCarpetCommentB] [nvarchar](max) NULL,
	[WallsAndFloorCarpetCommentE] [nvarchar](max) NULL,
	[FurnacePlumbingB] [int] NOT NULL,
	[FurnacePlumbingE] [int] NOT NULL,
	[FurnacePlumbingCommentB] [nvarchar](max) NULL,
	[FurnacePlumbingCommentE] [nvarchar](max) NULL,
 CONSTRAINT [PK_BasementCondition] PRIMARY KEY CLUSTERED 
(
	[PropertyInspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[ServiceRequestId] [int] NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[ResponderId] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DinningRoomCondition]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DinningRoomCondition](
	[PropertyInspectionId] [int] NOT NULL,
	[WallAndTrimeB] [int] NOT NULL,
	[WallAndTrimeE] [int] NOT NULL,
	[WallAndTrimsCommentB] [nvarchar](max) NULL,
	[WallAndTrimsCommentE] [nvarchar](max) NULL,
	[CeilingsB] [int] NOT NULL,
	[CeilingsE] [int] NOT NULL,
	[CeilingsCommentB] [nvarchar](max) NULL,
	[CeilingsCommentE] [nvarchar](max) NULL,
	[LightingB] [int] NOT NULL,
	[LightingE] [int] NOT NULL,
	[LightingCommentB] [nvarchar](max) NULL,
	[LightingCommentE] [nvarchar](max) NULL,
	[WindowsCoveringB] [int] NOT NULL,
	[WindowsCoveringE] [int] NOT NULL,
	[WindowsCoveringCommentB] [int] NOT NULL,
	[WindowsCoveringCommentE] [int] NOT NULL,
	[ElectricalOutletsB] [int] NOT NULL,
	[ElectricalOutletsE] [int] NOT NULL,
	[ElectricalOutletsCommentB] [nvarchar](max) NULL,
	[ElectricalOutletsCommentE] [nvarchar](max) NULL,
	[FloorCarpetB] [int] NOT NULL,
	[FloorCarpetE] [int] NOT NULL,
	[FloorCarpetCommentB] [nvarchar](max) NULL,
	[FloorCarpetCommentE] [nvarchar](max) NULL,
 CONSTRAINT [PK_DinningRoomCondition] PRIMARY KEY CLUSTERED 
(
	[PropertyInspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntryCondition]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntryCondition](
	[PropertyInspectionId] [int] NOT NULL,
	[WallAndTrimeB] [int] NOT NULL,
	[WallAndTrimeE] [int] NOT NULL,
	[WallAndTrimsCommentB] [nvarchar](max) NULL,
	[WallAndTrimsCommentE] [nvarchar](max) NULL,
	[CeilingsB] [int] NOT NULL,
	[CeilingsE] [int] NOT NULL,
	[CeilingsCommentB] [nvarchar](max) NULL,
	[CeilingsCommentE] [nvarchar](max) NULL,
	[ClosetsB] [int] NOT NULL,
	[ClosetsE] [int] NOT NULL,
	[ClosetsCommentB] [nvarchar](max) NULL,
	[ClosetsCommentE] [nvarchar](max) NULL,
	[LightingB] [int] NOT NULL,
	[LightingE] [int] NOT NULL,
	[LightingCommentB] [nvarchar](max) NULL,
	[LightingCommentE] [nvarchar](max) NULL,
	[WindowsCoveringB] [int] NOT NULL,
	[WindowsCoveringE] [int] NOT NULL,
	[WindowsCoveringCommentB] [int] NOT NULL,
	[WindowsCoveringCommentE] [int] NOT NULL,
	[ElectricalOutletsB] [int] NOT NULL,
	[ElectricalOutletsE] [int] NOT NULL,
	[ElectricalOutletsCommentB] [nvarchar](max) NULL,
	[ElectricalOutletsCommentE] [nvarchar](max) NULL,
	[FloorCarpetB] [int] NOT NULL,
	[FloorCarpetE] [int] NOT NULL,
	[FloorCarpetCommentB] [nvarchar](max) NULL,
	[FloorCarpetCommentE] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_EntryCondition] PRIMARY KEY CLUSTERED 
(
	[PropertyInspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExteriorCondition]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExteriorCondition](
	[PropertyInspectionId] [int] NOT NULL,
	[LightingB] [int] NOT NULL,
	[LightingE] [int] NOT NULL,
	[LightingCommentB] [nvarchar](max) NULL,
	[LightingCommentE] [nvarchar](max) NULL,
	[WindowsCoveringB] [int] NOT NULL,
	[WindowsCoveringE] [int] NOT NULL,
	[WindowsCoveringCommentB] [int] NOT NULL,
	[WindowsCoveringCommentE] [int] NOT NULL,
	[EntrancesB] [int] NOT NULL,
	[EntrancesE] [int] NOT NULL,
	[EntrancesCommentB] [nvarchar](max) NULL,
	[EntrancesCommentE] [nvarchar](max) NULL,
	[PatioBalconyDoorsB] [int] NOT NULL,
	[PatioBalconyDoorsE] [int] NOT NULL,
	[PatioBalconyDoorsCommentB] [int] NOT NULL,
	[PatioBalconyDoorsCommentE] [int] NOT NULL,
	[GarbageContainersB] [int] NOT NULL,
	[GarbageContainersE] [int] NOT NULL,
	[GarbageContainersCommentB] [int] NOT NULL,
	[GarbageContainersCommentE] [int] NOT NULL,
	[GlassAndFramesB] [int] NOT NULL,
	[GlassAndFramesE] [int] NOT NULL,
	[GlassAndFramesCommentB] [int] NOT NULL,
	[GlassAndFramesCommentE] [int] NOT NULL,
	[StuccoSidingB] [int] NOT NULL,
	[StuccoSidingE] [int] NOT NULL,
	[StuccoSidingCommentB] [int] NOT NULL,
	[StuccoSidingCommentE] [int] NOT NULL,
	[GroundsAndWalksB] [int] NOT NULL,
	[GroundsAndWalksE] [int] NOT NULL,
	[GroundsAndWalksCommentB] [int] NOT NULL,
	[GroundsAndWalksCommentE] [int] NOT NULL,
 CONSTRAINT [PK_ExteriorCondition] PRIMARY KEY CLUSTERED 
(
	[PropertyInspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GarageParkingAreaCondition]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GarageParkingAreaCondition](
	[PropertyInspectionId] [int] NOT NULL,
	[ElectricalOutletsB] [int] NOT NULL,
	[ElectricalOutletsE] [int] NOT NULL,
	[ElectricalOutletsCommentB] [nvarchar](max) NULL,
	[ElectricalOutletsCommentE] [nvarchar](max) NULL,
 CONSTRAINT [PK_GarageParkingAreaCondition] PRIMARY KEY CLUSTERED 
(
	[PropertyInspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inspection]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inspection](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[MoveInDate] [datetime2](7) NOT NULL,
	[MoveOutDate] [datetime2](7) NOT NULL,
	[MoveInInspectionDate] [datetime2](7) NOT NULL,
	[MoveOutIspectionDate] [datetime2](7) NOT NULL,
	[MoveInInspectionReportDocUrl] [nvarchar](max) NULL,
	[MoveOutInspectionReportDocUrl] [nvarchar](max) NULL,
	[LeaseId] [int] NOT NULL,
 CONSTRAINT [PK_Inspection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[WorkOrderId] [int] NOT NULL,
	[InvoiceAmount] [decimal](18, 2) NOT NULL,
	[InvoiceDocUrl] [nvarchar](max) NULL,
	[InvoiceDate] [datetime2](7) NOT NULL,
	[IsPaid] [bit] NOT NULL,
	[PaymentDate] [datetime2](7) NOT NULL,
	[PaymentMethod] [nvarchar](max) NULL,
	[PaymentAmount] [decimal](18, 2) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[InvoiceTitle] [nvarchar](max) NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KeyAndControlCondition]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeyAndControlCondition](
	[PropertyInspectionId] [int] NOT NULL,
	[EntranceKeysIssued] [nvarchar](max) NULL,
	[EntranceKeysReturned] [nvarchar](max) NULL,
	[UnitKeysIssed] [bit] NOT NULL,
	[UnitKeysReturned] [bit] NOT NULL,
	[EUnitDeadlocksIssed] [bit] NOT NULL,
	[EUnitDeadlocksReturned] [bit] NOT NULL,
	[ParkingRemoteControlIssed] [bit] NOT NULL,
	[ParkingRemoteControlReturned] [bit] NOT NULL,
 CONSTRAINT [PK_KeyAndControlCondition] PRIMARY KEY CLUSTERED 
(
	[PropertyInspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KitchenCondition]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KitchenCondition](
	[PropertyInspectionId] [int] NOT NULL,
	[WallAndTrimeB] [int] NOT NULL,
	[WallAndTrimeE] [int] NOT NULL,
	[WallAndTrimsCommentB] [nvarchar](max) NULL,
	[WallAndTrimsCommentE] [nvarchar](max) NULL,
	[CeilingsB] [int] NOT NULL,
	[CeilingsE] [int] NOT NULL,
	[CeilingsCommentB] [nvarchar](max) NULL,
	[CeilingsCommentE] [nvarchar](max) NULL,
	[ClosetsB] [int] NOT NULL,
	[ClosetsE] [int] NOT NULL,
	[ClosetsCommentB] [nvarchar](max) NULL,
	[ClosetsCommentE] [nvarchar](max) NULL,
	[LightingB] [int] NOT NULL,
	[LightingE] [int] NOT NULL,
	[LightingCommentB] [nvarchar](max) NULL,
	[LightingCommentE] [nvarchar](max) NULL,
	[WindowsCoveringB] [int] NOT NULL,
	[WindowsCoveringE] [int] NOT NULL,
	[WindowsCoveringCommentB] [int] NOT NULL,
	[WindowsCoveringCommentE] [int] NOT NULL,
	[ElectricalOutletsB] [int] NOT NULL,
	[ElectricalOutletsE] [int] NOT NULL,
	[ElectricalOutletsCommentB] [nvarchar](max) NULL,
	[ElectricalOutletsCommentE] [nvarchar](max) NULL,
	[FloorCarpetB] [int] NOT NULL,
	[FloorCarpetE] [int] NOT NULL,
	[FloorCarpetCommentB] [nvarchar](max) NULL,
	[FloorCarpetCommentE] [nvarchar](max) NULL,
	[OvenB] [int] NOT NULL,
	[OvenE] [int] NOT NULL,
	[OvenCommentB] [int] NOT NULL,
	[OvenCommentE] [int] NOT NULL,
	[CountertopB] [int] NOT NULL,
	[CountertopE] [int] NOT NULL,
	[CountertopCommentB] [nvarchar](max) NULL,
	[CountertopCommentE] [nvarchar](max) NULL,
	[CabinetsAndDoorsB] [int] NOT NULL,
	[CabinetsAndDoorsE] [int] NOT NULL,
	[CabinetsAndDoorsCommentB] [nvarchar](max) NULL,
	[CabinetsAndDoorsCommentE] [nvarchar](max) NULL,
	[HoodAndFanB] [int] NOT NULL,
	[HoodAndFanE] [int] NOT NULL,
	[HoodAndCommentFanB] [nvarchar](max) NULL,
	[HoodAndCommentFanE] [nvarchar](max) NULL,
	[TapsSinksB] [int] NOT NULL,
	[TapsSinksE] [int] NOT NULL,
	[TapsSinksCommentB] [nvarchar](max) NULL,
	[TapsSinksCommentE] [nvarchar](max) NULL,
	[RefrigeratorExteriorB] [int] NOT NULL,
	[RefrigeratorExteriorE] [int] NOT NULL,
	[RefrigeratorExteriorCommentB] [nvarchar](max) NULL,
	[RefrigeratorExteriorCommentE] [nvarchar](max) NULL,
	[RefrigeratorShelfB] [int] NOT NULL,
	[RefrigeratorShelfE] [int] NOT NULL,
	[RefrigeratorShelfCommentB] [nvarchar](max) NULL,
	[RefrigeratorShelfCommentE] [nvarchar](max) NULL,
	[RefrigeratorFreezerB] [int] NOT NULL,
	[RefrigeratorFreezerE] [int] NOT NULL,
	[RefrigeratorFreezerCommentB] [nvarchar](max) NULL,
	[RefrigeratorFreezerCommentE] [nvarchar](max) NULL,
	[DishwasherB] [int] NOT NULL,
	[DishwasherE] [int] NOT NULL,
	[DishwasherCommentB] [nvarchar](max) NULL,
	[DishwasherCommentE] [nvarchar](max) NULL,
	[StoveB] [int] NOT NULL,
	[StoveE] [int] NOT NULL,
	[StoveCommentB] [nvarchar](max) NULL,
	[StoveCommentE] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_KitchenCondition] PRIMARY KEY CLUSTERED 
(
	[PropertyInspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lease]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lease](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[LeaseTitle] [nvarchar](150) NOT NULL,
	[LeaseDesc] [nvarchar](4000) NULL,
	[RentalPropertyId] [int] NOT NULL,
	[LeaseStartDate] [datetime2](7) NOT NULL,
	[LeaseEndDate] [datetime2](7) NOT NULL,
	[RentFrequency] [nvarchar](50) NOT NULL,
	[RentAmount] [decimal](18, 0) NOT NULL,
	[RentDueOn] [nvarchar](150) NOT NULL,
	[DamageDepositAmount] [decimal](18, 0) NOT NULL,
	[PetDepositAmount] [decimal](18, 0) NULL,
	[LeaseSignDate] [datetime2](7) NOT NULL,
	[LeaseAgreementDocUrl] [varchar](10) NULL,
	[IsActive] [bit] NOT NULL,
	[IsAddendumAvailable] [bit] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Term] [nvarchar](max) NOT NULL,
	[EndLeaseCode] [int] NOT NULL,
	[RenewTerm] [nvarchar](max) NULL,
 CONSTRAINT [PK_Lease] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LivingRoomCondition]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LivingRoomCondition](
	[PropertyInspectionId] [int] NOT NULL,
	[WallAndTrimeB] [int] NOT NULL,
	[WallAndTrimeE] [int] NOT NULL,
	[WallAndTrimsCommentB] [nvarchar](max) NULL,
	[WallAndTrimsCommentE] [nvarchar](max) NULL,
	[CeilingsB] [int] NOT NULL,
	[CeilingsE] [int] NOT NULL,
	[CeilingsCommentB] [nvarchar](max) NULL,
	[CeilingsCommentE] [nvarchar](max) NULL,
	[ClosetsB] [int] NOT NULL,
	[ClosetsE] [int] NOT NULL,
	[ClosetsCommentB] [nvarchar](max) NULL,
	[ClosetsCommentE] [nvarchar](max) NULL,
	[LightingB] [int] NOT NULL,
	[LightingE] [int] NOT NULL,
	[LightingCommentB] [nvarchar](max) NULL,
	[LightingCommentE] [nvarchar](max) NULL,
	[WindowsCoveringB] [int] NOT NULL,
	[WindowsCoveringE] [int] NOT NULL,
	[WindowsCoveringCommentB] [int] NOT NULL,
	[WindowsCoveringCommentE] [int] NOT NULL,
	[ElectricalOutletsB] [int] NOT NULL,
	[ElectricalOutletsE] [int] NOT NULL,
	[ElectricalOutletsCommentB] [nvarchar](max) NULL,
	[ElectricalOutletsCommentE] [nvarchar](max) NULL,
	[FloorCarpetB] [int] NOT NULL,
	[FloorCarpetE] [int] NOT NULL,
	[FloorCarpetCommentB] [nvarchar](max) NULL,
	[FloorCarpetCommentE] [nvarchar](max) NULL,
	[AirConditionerB] [int] NOT NULL,
	[AirConditionerE] [int] NOT NULL,
	[AirConditionerCommentB] [nvarchar](max) NULL,
	[AirConditionerCommentE] [nvarchar](max) NULL,
	[CableTVB] [int] NOT NULL,
	[CableTVE] [int] NOT NULL,
	[CableTVCommentB] [nvarchar](max) NULL,
	[CableTVCommentE] [nvarchar](max) NULL,
	[FireplaceB] [int] NOT NULL,
	[FireplaceE] [int] NOT NULL,
	[FireplaceCommentB] [nvarchar](max) NULL,
	[FireplaceCommentE] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_LivingRoomCondition] PRIMARY KEY CLUSTERED 
(
	[PropertyInspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MainBathroomCondition]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MainBathroomCondition](
	[PropertyInspectionId] [int] NOT NULL,
	[WallAndTrimeB] [int] NOT NULL,
	[WallAndTrimeE] [int] NOT NULL,
	[WallAndTrimsCommentB] [nvarchar](max) NULL,
	[WallAndTrimsCommentE] [nvarchar](max) NULL,
	[CeilingsB] [int] NOT NULL,
	[CeilingsE] [int] NOT NULL,
	[CeilingsCommentB] [nvarchar](max) NULL,
	[CeilingsCommentE] [nvarchar](max) NULL,
	[ClosetsB] [int] NOT NULL,
	[ClosetsE] [int] NOT NULL,
	[ClosetsCommentB] [nvarchar](max) NULL,
	[ClosetsCommentE] [nvarchar](max) NULL,
	[ToiletB] [int] NOT NULL,
	[ToiletE] [int] NOT NULL,
	[ToiletCommentB] [nvarchar](max) NULL,
	[ToiletCommentE] [nvarchar](max) NULL,
	[DoorB] [int] NOT NULL,
	[DoorE] [int] NOT NULL,
	[DoorCommentB] [nvarchar](max) NULL,
	[DoorCommentE] [nvarchar](max) NULL,
	[SinkB] [int] NOT NULL,
	[SinkE] [int] NOT NULL,
	[SinkCommentB] [nvarchar](max) NULL,
	[SinkCommentE] [nvarchar](max) NULL,
	[ShowerTubB] [int] NOT NULL,
	[ShowerTubE] [int] NOT NULL,
	[ShowerTubCommentB] [nvarchar](max) NULL,
	[ShowerTubCommentE] [nvarchar](max) NULL,
	[LightingB] [int] NOT NULL,
	[LightingE] [int] NOT NULL,
	[LightingCommentB] [nvarchar](max) NULL,
	[LightingCommentE] [nvarchar](max) NULL,
	[WindowsCoveringB] [int] NOT NULL,
	[WindowsCoveringE] [int] NOT NULL,
	[WindowsCoveringCommentB] [int] NOT NULL,
	[WindowsCoveringCommentE] [int] NOT NULL,
	[ElectricalOutletsB] [int] NOT NULL,
	[ElectricalOutletsE] [int] NOT NULL,
	[ElectricalOutletsCommentB] [nvarchar](max) NULL,
	[ElectricalOutletsCommentE] [nvarchar](max) NULL,
	[FloorCarpetB] [int] NOT NULL,
	[FloorCarpetE] [int] NOT NULL,
	[FloorCarpetCommentB] [nvarchar](max) NULL,
	[FloorCarpetCommentE] [nvarchar](max) NULL,
 CONSTRAINT [PK_MainBathroomCondition] PRIMARY KEY CLUSTERED 
(
	[PropertyInspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterBedroomCondition]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterBedroomCondition](
	[PropertyInspectionId] [int] NOT NULL,
	[WallAndTrimeB] [int] NOT NULL,
	[WallAndTrimeE] [int] NOT NULL,
	[WallAndTrimsCommentB] [nvarchar](max) NULL,
	[WallAndTrimsCommentE] [nvarchar](max) NULL,
	[CeilingsB] [int] NOT NULL,
	[CeilingsE] [int] NOT NULL,
	[CeilingsCommentB] [nvarchar](max) NULL,
	[CeilingsCommentE] [nvarchar](max) NULL,
	[ClosetsB] [int] NOT NULL,
	[ClosetsE] [int] NOT NULL,
	[ClosetsCommentB] [nvarchar](max) NULL,
	[ClosetsCommentE] [nvarchar](max) NULL,
	[DoorB] [int] NOT NULL,
	[DoorE] [int] NOT NULL,
	[DoorCommentB] [nvarchar](max) NULL,
	[DoorCommentE] [nvarchar](max) NULL,
	[LightingB] [int] NOT NULL,
	[LightingE] [int] NOT NULL,
	[LightingCommentB] [nvarchar](max) NULL,
	[LightingCommentE] [nvarchar](max) NULL,
	[WindowsCoveringB] [int] NOT NULL,
	[WindowsCoveringE] [int] NOT NULL,
	[WindowsCoveringCommentB] [int] NOT NULL,
	[WindowsCoveringCommentE] [int] NOT NULL,
	[ElectricalOutletsB] [int] NOT NULL,
	[ElectricalOutletsE] [int] NOT NULL,
	[ElectricalOutletsCommentB] [nvarchar](max) NULL,
	[ElectricalOutletsCommentE] [nvarchar](max) NULL,
	[FloorCarpetB] [int] NOT NULL,
	[FloorCarpetE] [int] NOT NULL,
	[FloorCarpetCommentB] [nvarchar](max) NULL,
	[FloorCarpetCommentE] [nvarchar](max) NULL,
 CONSTRAINT [PK_MasterBedroomCondition] PRIMARY KEY CLUSTERED 
(
	[PropertyInspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewTenant]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewTenant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[ContactEmail] [nvarchar](150) NOT NULL,
	[ContactTelephone1] [nvarchar](50) NOT NULL,
	[ContactTelephone2] [nvarchar](50) NULL,
	[ContactOthers] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_NewTenant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OtherBedroomCondition]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtherBedroomCondition](
	[PropertyInspectionId] [int] NOT NULL,
	[WallAndTrimeB] [int] NOT NULL,
	[WallAndTrimeE] [int] NOT NULL,
	[WallAndTrimsCommentB] [nvarchar](max) NULL,
	[WallAndTrimsCommentE] [nvarchar](max) NULL,
	[CeilingsB] [int] NOT NULL,
	[CeilingsE] [int] NOT NULL,
	[CeilingsCommentB] [nvarchar](max) NULL,
	[CeilingsCommentE] [nvarchar](max) NULL,
	[ClosetsB] [int] NOT NULL,
	[ClosetsE] [int] NOT NULL,
	[ClosetsCommentB] [nvarchar](max) NULL,
	[ClosetsCommentE] [nvarchar](max) NULL,
	[DoorB] [int] NOT NULL,
	[DoorE] [int] NOT NULL,
	[DoorCommentB] [nvarchar](max) NULL,
	[DoorCommentE] [nvarchar](max) NULL,
	[LightingB] [int] NOT NULL,
	[LightingE] [int] NOT NULL,
	[LightingCommentB] [nvarchar](max) NULL,
	[LightingCommentE] [nvarchar](max) NULL,
	[WindowsCoveringB] [int] NOT NULL,
	[WindowsCoveringE] [int] NOT NULL,
	[WindowsCoveringCommentB] [int] NOT NULL,
	[WindowsCoveringCommentE] [int] NOT NULL,
	[ElectricalOutletsB] [int] NOT NULL,
	[ElectricalOutletsE] [int] NOT NULL,
	[ElectricalOutletsCommentB] [nvarchar](max) NULL,
	[ElectricalOutletsCommentE] [nvarchar](max) NULL,
	[FloorCarpetB] [int] NOT NULL,
	[FloorCarpetE] [int] NOT NULL,
	[FloorCarpetCommentB] [nvarchar](max) NULL,
	[FloorCarpetCommentE] [nvarchar](max) NULL,
 CONSTRAINT [PK_OtherBedroomCondition] PRIMARY KEY CLUSTERED 
(
	[PropertyInspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OwnerAddress]    Script Date: 10/31/2020 10:13:50 AM ******/
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
/****** Object:  Table [dbo].[PropertyVisit]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyVisit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[RentalPropertyId] [int] NOT NULL,
	[VisitPurpose] [nvarchar](150) NOT NULL,
	[MileageDriven] [nvarchar](100) NULL,
	[TimeSpent] [nvarchar](50) NOT NULL,
	[VisitDate] [datetime2](7) NOT NULL,
	[VisitStartTime] [nvarchar](50) NOT NULL,
	[VisitEndTime] [nvarchar](50) NOT NULL,
	[HoursSpent] [decimal](18, 0) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[UpdatedOn] [datetime2](7) NOT NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_PropertyVisit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalProperty]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalProperty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[ListinglId] [int] NOT NULL,
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
	[OriginalId] [int] NOT NULL,
 CONSTRAINT [PK_RentalProperty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalPropertyOwner]    Script Date: 10/31/2020 10:13:50 AM ******/
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
/****** Object:  Table [dbo].[RentCoverage]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentCoverage](
	[LeaseId] [int] NOT NULL,
	[Water] [bit] NOT NULL,
	[Cablevison] [bit] NOT NULL,
	[Electricity] [bit] NOT NULL,
	[Internet] [bit] NOT NULL,
	[Heat] [bit] NOT NULL,
	[NaturalGas] [bit] NOT NULL,
	[SewageDisposal] [bit] NOT NULL,
	[SnowRemoval] [bit] NOT NULL,
	[Storage] [bit] NOT NULL,
	[RecreationFacility] [bit] NOT NULL,
	[GarbageCollection] [bit] NOT NULL,
	[RecycleServices] [bit] NOT NULL,
	[KitchenScrapCollection] [bit] NOT NULL,
	[Laundry] [bit] NOT NULL,
	[FreeLaundry] [bit] NULL,
	[Regigerator] [bit] NOT NULL,
	[Dishwasher] [bit] NOT NULL,
	[StoveOven] [bit] NOT NULL,
	[WindowCovering] [bit] NOT NULL,
	[Furniture] [bit] NOT NULL,
	[Carpets] [bit] NOT NULL,
	[ParkingStall] [int] NOT NULL,
	[Other] [nvarchar](max) NULL,
 CONSTRAINT [PK_RentCoverage] PRIMARY KEY CLUSTERED 
(
	[LeaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentPayment]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentPayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[LeaseId] [int] NOT NULL,
	[ScheduledPaymentAmt] [decimal](18, 0) NOT NULL,
	[ActualPaymentAmt] [decimal](18, 0) NOT NULL,
	[PaymentDueDate] [datetime2](7) NULL,
	[PaymentReceivedDate] [datetime2](7) NULL,
	[Balance] [decimal](18, 0) NULL,
	[IsOnTime] [bit] NOT NULL,
	[InChargeTenantId] [int] NOT NULL,
	[Note] [nvarchar](450) NULL,
	[PayMethod] [nvarchar](max) NOT NULL,
	[RentalForMonth] [nvarchar](max) NULL,
	[RentalForYear] [nvarchar](max) NULL,
 CONSTRAINT [PK_RentPayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[RequestSubject] [nvarchar](max) NULL,
	[ServiceCategory] [nvarchar](max) NULL,
	[RequestDetails] [nvarchar](1000) NULL,
	[Urgent] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[LeaseId] [int] NOT NULL,
	[RequestorId] [int] NOT NULL,
	[WorkOrderId] [int] NOT NULL,
	[Notes] [nvarchar](450) NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StairWayHallWayCondition]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StairWayHallWayCondition](
	[PropertyInspectionId] [int] NOT NULL,
	[WallAndTrimeB] [int] NOT NULL,
	[WallAndTrimeE] [int] NOT NULL,
	[WallAndTrimsCommentB] [nvarchar](max) NULL,
	[WallAndTrimsCommentE] [nvarchar](max) NULL,
	[CeilingsB] [int] NOT NULL,
	[CeilingsE] [int] NOT NULL,
	[CeilingsCommentB] [nvarchar](max) NULL,
	[CeilingsCommentE] [nvarchar](max) NULL,
	[LightingB] [int] NOT NULL,
	[LightingE] [int] NOT NULL,
	[LightingCommentB] [nvarchar](max) NULL,
	[LightingCommentE] [nvarchar](max) NULL,
	[WindowsCoveringB] [int] NOT NULL,
	[WindowsCoveringE] [int] NOT NULL,
	[WindowsCoveringCommentB] [int] NOT NULL,
	[WindowsCoveringCommentE] [int] NOT NULL,
	[ElectricalOutletsB] [int] NOT NULL,
	[ElectricalOutletsE] [int] NOT NULL,
	[ElectricalOutletsCommentB] [nvarchar](max) NULL,
	[ElectricalOutletsCommentE] [nvarchar](max) NULL,
	[ClosetsB] [int] NOT NULL,
	[ClosetsE] [int] NOT NULL,
	[ClosetsCommentB] [nvarchar](max) NULL,
	[ClosetsCommentE] [nvarchar](max) NULL,
	[TreadsAndLandingsB] [int] NOT NULL,
	[TreadsAndLandingsE] [int] NOT NULL,
	[TreadsAndLandingsCommentB] [nvarchar](max) NULL,
	[TreadsAndLandingsCommentE] [nvarchar](max) NULL,
	[RailingB] [int] NOT NULL,
	[RailingE] [int] NOT NULL,
	[RailingCommentB] [nvarchar](max) NULL,
	[RailingCommentE] [nvarchar](max) NULL,
 CONSTRAINT [PK_StairWayHallWayCondition] PRIMARY KEY CLUSTERED 
(
	[PropertyInspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StorageCondition]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StorageCondition](
	[PropertyInspectionId] [int] NOT NULL,
	[ConditionB] [int] NOT NULL,
	[ConditionE] [int] NOT NULL,
	[ConditionCommentB] [nvarchar](max) NULL,
	[ConditionCommentE] [nvarchar](max) NULL,
 CONSTRAINT [PK_StorageCondition] PRIMARY KEY CLUSTERED 
(
	[PropertyInspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenant]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[ContactEmail] [nvarchar](150) NOT NULL,
	[ContactTelephone1] [nvarchar](50) NOT NULL,
	[ContactTelephone2] [nvarchar](50) NULL,
	[ContactOthers] [nvarchar](250) NOT NULL,
	[OnlineAccessEnbaled] [bit] NOT NULL,
	[UserAvartaImgUrl] [nvarchar](200) NOT NULL,
	[LeaseId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UtilityRoomCondition]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UtilityRoomCondition](
	[PropertyInspectionId] [int] NOT NULL,
	[ElectricalOutletsB] [int] NOT NULL,
	[ElectricalOutletsE] [int] NOT NULL,
	[ElectricalOutletsCommentB] [nvarchar](max) NULL,
	[ElectricalOutletsCommentE] [nvarchar](max) NULL,
	[WasherDryerB] [int] NOT NULL,
	[WasherDryerE] [int] NOT NULL,
	[WasherDryerCommentB] [nvarchar](max) NULL,
	[WasherDryerCommentE] [nvarchar](max) NULL,
 CONSTRAINT [PK_UtilityRoomCondition] PRIMARY KEY CLUSTERED 
(
	[PropertyInspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendor](
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[VendorBusinessName] [varchar](150) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[VendorDesc] [varchar](450) NULL,
	[VendorSpecialty] [nvarchar](150) NOT NULL,
	[VendorContactTelephone1] [varchar](30) NOT NULL,
	[VendorContactOthers] [varchar](100) NULL,
	[VendorContactEmail] [varchar](100) NULL,
	[IsActive] [bit] NOT NULL,
	[RoleId] [int] NOT NULL,
	[OnlineAccessEnbaled] [bit] NOT NULL,
	[UserAvartaImgUrl] [varchar](100) NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkOrder]    Script Date: 10/31/2020 10:13:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[WorkOrderName] [varchar](50) NOT NULL,
	[WorkOrderDetails] [varchar](500) NOT NULL,
	[WorkOrderCategory] [nvarchar](50) NOT NULL,
	[RentalPropertyId] [int] NOT NULL,
	[VendorId] [int] NOT NULL,
	[ServiceRequestId] [int] NULL,
	[WorkOrderType] [nvarchar](50) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[IsOwnerAuthorized] [bit] NOT NULL,
	[IsEmergency] [bit] NOT NULL,
	[WorkOrderStatus] [nvarchar](50) NOT NULL,
	[Note] [nvarchar](550) NULL,
 CONSTRAINT [PK_WorkOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Created]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Modified]
GO
ALTER TABLE [dbo].[Lease] ADD  DEFAULT (N'') FOR [Term]
GO
ALTER TABLE [dbo].[Lease] ADD  DEFAULT ((0)) FOR [EndLeaseCode]
GO
ALTER TABLE [dbo].[RentalProperty] ADD  DEFAULT ((0)) FOR [OriginalId]
GO
ALTER TABLE [dbo].[Tenant] ADD  DEFAULT ('tba') FOR [UserName]
GO
ALTER TABLE [dbo].[Tenant] ADD  DEFAULT ('default') FOR [UserAvartaImgUrl]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_RentalProperty_RentalPropertyId] FOREIGN KEY([RentalPropertyId])
REFERENCES [dbo].[RentalProperty] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_RentalProperty_RentalPropertyId]
GO
ALTER TABLE [dbo].[Agent]  WITH CHECK ADD  CONSTRAINT [FK_Agent_Lease] FOREIGN KEY([LeaseId])
REFERENCES [dbo].[Lease] ([Id])
GO
ALTER TABLE [dbo].[Agent] CHECK CONSTRAINT [FK_Agent_Lease]
GO
ALTER TABLE [dbo].[BasementCondition]  WITH CHECK ADD  CONSTRAINT [FK_BasementCondition_Inspection_PropertyInspectionId] FOREIGN KEY([PropertyInspectionId])
REFERENCES [dbo].[Inspection] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BasementCondition] CHECK CONSTRAINT [FK_BasementCondition_Inspection_PropertyInspectionId]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_ServiceRequestComment_ServiceRequest] FOREIGN KEY([ServiceRequestId])
REFERENCES [dbo].[Request] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_ServiceRequestComment_ServiceRequest]
GO
ALTER TABLE [dbo].[DinningRoomCondition]  WITH CHECK ADD  CONSTRAINT [FK_DinningRoomCondition_Inspection_PropertyInspectionId] FOREIGN KEY([PropertyInspectionId])
REFERENCES [dbo].[Inspection] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DinningRoomCondition] CHECK CONSTRAINT [FK_DinningRoomCondition_Inspection_PropertyInspectionId]
GO
ALTER TABLE [dbo].[EntryCondition]  WITH CHECK ADD  CONSTRAINT [FK_EntryCondition_Inspection_PropertyInspectionId] FOREIGN KEY([PropertyInspectionId])
REFERENCES [dbo].[Inspection] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EntryCondition] CHECK CONSTRAINT [FK_EntryCondition_Inspection_PropertyInspectionId]
GO
ALTER TABLE [dbo].[ExteriorCondition]  WITH CHECK ADD  CONSTRAINT [FK_ExteriorCondition_Inspection_PropertyInspectionId] FOREIGN KEY([PropertyInspectionId])
REFERENCES [dbo].[Inspection] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExteriorCondition] CHECK CONSTRAINT [FK_ExteriorCondition_Inspection_PropertyInspectionId]
GO
ALTER TABLE [dbo].[GarageParkingAreaCondition]  WITH CHECK ADD  CONSTRAINT [FK_GarageParkingAreaCondition_Inspection_PropertyInspectionId] FOREIGN KEY([PropertyInspectionId])
REFERENCES [dbo].[Inspection] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GarageParkingAreaCondition] CHECK CONSTRAINT [FK_GarageParkingAreaCondition_Inspection_PropertyInspectionId]
GO
ALTER TABLE [dbo].[Inspection]  WITH CHECK ADD  CONSTRAINT [FK_PriopertyInspection_Lease] FOREIGN KEY([LeaseId])
REFERENCES [dbo].[Lease] ([Id])
GO
ALTER TABLE [dbo].[Inspection] CHECK CONSTRAINT [FK_PriopertyInspection_Lease]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_WorkOrder_WorkOrderId] FOREIGN KEY([WorkOrderId])
REFERENCES [dbo].[WorkOrder] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_WorkOrder_WorkOrderId]
GO
ALTER TABLE [dbo].[KeyAndControlCondition]  WITH CHECK ADD  CONSTRAINT [FK_KeyAndControlCondition_Inspection_PropertyInspectionId] FOREIGN KEY([PropertyInspectionId])
REFERENCES [dbo].[Inspection] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KeyAndControlCondition] CHECK CONSTRAINT [FK_KeyAndControlCondition_Inspection_PropertyInspectionId]
GO
ALTER TABLE [dbo].[KitchenCondition]  WITH CHECK ADD  CONSTRAINT [FK_KitchenCondition_Inspection_PropertyInspectionId] FOREIGN KEY([PropertyInspectionId])
REFERENCES [dbo].[Inspection] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KitchenCondition] CHECK CONSTRAINT [FK_KitchenCondition_Inspection_PropertyInspectionId]
GO
ALTER TABLE [dbo].[Lease]  WITH CHECK ADD  CONSTRAINT [FK_Lease_RentalProperty] FOREIGN KEY([RentalPropertyId])
REFERENCES [dbo].[RentalProperty] ([Id])
GO
ALTER TABLE [dbo].[Lease] CHECK CONSTRAINT [FK_Lease_RentalProperty]
GO
ALTER TABLE [dbo].[LivingRoomCondition]  WITH CHECK ADD  CONSTRAINT [FK_LivingRoomCondition_Inspection_PropertyInspectionId] FOREIGN KEY([PropertyInspectionId])
REFERENCES [dbo].[Inspection] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LivingRoomCondition] CHECK CONSTRAINT [FK_LivingRoomCondition_Inspection_PropertyInspectionId]
GO
ALTER TABLE [dbo].[MainBathroomCondition]  WITH CHECK ADD  CONSTRAINT [FK_MainBathroomCondition_Inspection_PropertyInspectionId] FOREIGN KEY([PropertyInspectionId])
REFERENCES [dbo].[Inspection] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MainBathroomCondition] CHECK CONSTRAINT [FK_MainBathroomCondition_Inspection_PropertyInspectionId]
GO
ALTER TABLE [dbo].[MasterBedroomCondition]  WITH CHECK ADD  CONSTRAINT [FK_MasterBedroomCondition_Inspection_PropertyInspectionId] FOREIGN KEY([PropertyInspectionId])
REFERENCES [dbo].[Inspection] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MasterBedroomCondition] CHECK CONSTRAINT [FK_MasterBedroomCondition_Inspection_PropertyInspectionId]
GO
ALTER TABLE [dbo].[OtherBedroomCondition]  WITH CHECK ADD  CONSTRAINT [FK_OtherBedroomCondition_Inspection_PropertyInspectionId] FOREIGN KEY([PropertyInspectionId])
REFERENCES [dbo].[Inspection] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OtherBedroomCondition] CHECK CONSTRAINT [FK_OtherBedroomCondition_Inspection_PropertyInspectionId]
GO
ALTER TABLE [dbo].[OwnerAddress]  WITH CHECK ADD  CONSTRAINT [FK_OwnerAddress_RentalPropertyOwner_RentalPropertyOwnerId] FOREIGN KEY([RentalPropertyOwnerId])
REFERENCES [dbo].[RentalPropertyOwner] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OwnerAddress] CHECK CONSTRAINT [FK_OwnerAddress_RentalPropertyOwner_RentalPropertyOwnerId]
GO
ALTER TABLE [dbo].[PropertyVisit]  WITH CHECK ADD  CONSTRAINT [FK_PropertyVisit_RentalProperty] FOREIGN KEY([RentalPropertyId])
REFERENCES [dbo].[RentalProperty] ([Id])
GO
ALTER TABLE [dbo].[PropertyVisit] CHECK CONSTRAINT [FK_PropertyVisit_RentalProperty]
GO
ALTER TABLE [dbo].[RentalPropertyOwner]  WITH CHECK ADD  CONSTRAINT [FK_PropertyOwner_RentalProperty] FOREIGN KEY([RentalPropertyId])
REFERENCES [dbo].[RentalProperty] ([Id])
GO
ALTER TABLE [dbo].[RentalPropertyOwner] CHECK CONSTRAINT [FK_PropertyOwner_RentalProperty]
GO
ALTER TABLE [dbo].[RentCoverage]  WITH CHECK ADD  CONSTRAINT [FK_RentCoverage_Lease_LeaseId] FOREIGN KEY([LeaseId])
REFERENCES [dbo].[Lease] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RentCoverage] CHECK CONSTRAINT [FK_RentCoverage_Lease_LeaseId]
GO
ALTER TABLE [dbo].[RentPayment]  WITH CHECK ADD  CONSTRAINT [FK_RentPayment_Lease] FOREIGN KEY([LeaseId])
REFERENCES [dbo].[Lease] ([Id])
GO
ALTER TABLE [dbo].[RentPayment] CHECK CONSTRAINT [FK_RentPayment_Lease]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_ServieRequest_Lease] FOREIGN KEY([LeaseId])
REFERENCES [dbo].[Lease] ([Id])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_ServieRequest_Lease]
GO
ALTER TABLE [dbo].[StairWayHallWayCondition]  WITH CHECK ADD  CONSTRAINT [FK_StairWayHallWayCondition_Inspection_PropertyInspectionId] FOREIGN KEY([PropertyInspectionId])
REFERENCES [dbo].[Inspection] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StairWayHallWayCondition] CHECK CONSTRAINT [FK_StairWayHallWayCondition_Inspection_PropertyInspectionId]
GO
ALTER TABLE [dbo].[StorageCondition]  WITH CHECK ADD  CONSTRAINT [FK_StorageCondition_Inspection_PropertyInspectionId] FOREIGN KEY([PropertyInspectionId])
REFERENCES [dbo].[Inspection] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StorageCondition] CHECK CONSTRAINT [FK_StorageCondition_Inspection_PropertyInspectionId]
GO
ALTER TABLE [dbo].[Tenant]  WITH CHECK ADD  CONSTRAINT [FK_Tenant_Lease] FOREIGN KEY([LeaseId])
REFERENCES [dbo].[Lease] ([Id])
GO
ALTER TABLE [dbo].[Tenant] CHECK CONSTRAINT [FK_Tenant_Lease]
GO
ALTER TABLE [dbo].[UtilityRoomCondition]  WITH CHECK ADD  CONSTRAINT [FK_UtilityRoomCondition_Inspection_PropertyInspectionId] FOREIGN KEY([PropertyInspectionId])
REFERENCES [dbo].[Inspection] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UtilityRoomCondition] CHECK CONSTRAINT [FK_UtilityRoomCondition_Inspection_PropertyInspectionId]
GO
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_RentalProperty] FOREIGN KEY([RentalPropertyId])
REFERENCES [dbo].[RentalProperty] ([Id])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_RentalProperty]
GO
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_Vendor] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendor] ([Id])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_Vendor]
GO
