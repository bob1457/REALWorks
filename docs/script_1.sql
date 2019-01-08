IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Property] (
    [PropertyId] int NOT NULL IDENTITY,
    [PropertyName] nvarchar(50) NOT NULL,
    [PropertyDesc] nvarchar(250) NULL,
    [PropertyTypeId] int NOT NULL,
    [StrataCouncilId] int NULL DEFAULT (((0))),
    [PropertyFeatureId] int NOT NULL,
    [PropertyFacilityId] int NOT NULL,
    [PropertyManagerId] int NULL DEFAULT (((0))),
    [PropertyLogoImgUrl] nvarchar(100) NULL,
    [PropertyVideoUrl] nvarchar(100) NULL,
    [PropertyBuildYear] int NOT NULL,
    [IsActive] bit NOT NULL DEFAULT (((1))),
    [IsShared] bit NOT NULL,
    [FurnishingId] int NULL DEFAULT (((0))),
    [RentalStatusId] int NOT NULL,
    [IsBasementSuite] bit NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NOT NULL,
    [Address_PropertySuiteNumber] nvarchar(max) NULL,
    [Address_PropertyNumber] nvarchar(max) NULL,
    [Address_PropertyStreet] nvarchar(max) NULL,
    [Address_PropertyCity] nvarchar(max) NULL,
    [Address_PropertyStateProvince] nvarchar(max) NULL,
    [Address_PropertyCountry] nvarchar(max) NULL,
    [Address_PropertyZipPostCode] nvarchar(max) NULL,
    [Address_GpslongitudeValue] nvarchar(max) NULL,
    [Address_GpslatitudeValue] nvarchar(max) NULL,
    CONSTRAINT [PK_Property] PRIMARY KEY ([PropertyId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190104173819_initial', N'2.1.4-rtm-31024');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Property]') AND [c].[name] = N'Address_GpslatitudeValue');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Property] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Property] DROP COLUMN [Address_GpslatitudeValue];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Property]') AND [c].[name] = N'Address_GpslongitudeValue');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Property] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Property] DROP COLUMN [Address_GpslongitudeValue];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Property]') AND [c].[name] = N'Address_PropertyCity');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Property] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Property] DROP COLUMN [Address_PropertyCity];

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Property]') AND [c].[name] = N'Address_PropertyCountry');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Property] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Property] DROP COLUMN [Address_PropertyCountry];

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Property]') AND [c].[name] = N'Address_PropertyNumber');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Property] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Property] DROP COLUMN [Address_PropertyNumber];

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Property]') AND [c].[name] = N'Address_PropertyStateProvince');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Property] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Property] DROP COLUMN [Address_PropertyStateProvince];

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Property]') AND [c].[name] = N'Address_PropertyStreet');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Property] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Property] DROP COLUMN [Address_PropertyStreet];

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Property]') AND [c].[name] = N'Address_PropertySuiteNumber');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Property] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Property] DROP COLUMN [Address_PropertySuiteNumber];

GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Property]') AND [c].[name] = N'Address_PropertyZipPostCode');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Property] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Property] DROP COLUMN [Address_PropertyZipPostCode];

GO

CREATE TABLE [PropertyAddress] (
    [PropertySuiteNumber] nvarchar(max) NULL,
    [PropertyNumber] nvarchar(max) NULL,
    [PropertyStreet] nvarchar(max) NULL,
    [PropertyCity] nvarchar(max) NULL,
    [PropertyStateProvince] nvarchar(max) NULL,
    [PropertyCountry] nvarchar(max) NULL,
    [PropertyZipPostCode] nvarchar(max) NULL,
    [GpslongitudeValue] nvarchar(max) NULL,
    [GpslatitudeValue] nvarchar(max) NULL,
    [PropertyId] int NOT NULL,
    CONSTRAINT [PK_PropertyAddress] PRIMARY KEY ([PropertyId]),
    CONSTRAINT [FK_PropertyAddress_Property_PropertyId] FOREIGN KEY ([PropertyId]) REFERENCES [Property] ([PropertyId])
ON DELETE CASCADE
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190104175705_modified', N'2.1.4-rtm-31024');

GO

EXEC sp_rename N'[Property].[UpdateDate]', N'Modified', N'COLUMN';

GO

EXEC sp_rename N'[Property].[CreatedDate]', N'Created', N'COLUMN';

GO

EXEC sp_rename N'[Property].[PropertyId]', N'Id', N'COLUMN';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190104192451_modified2', N'2.1.4-rtm-31024');

GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Property]') AND [c].[name] = N'FurnishingId');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Property] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Property] DROP COLUMN [FurnishingId];

GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Property]') AND [c].[name] = N'PropertyFacilityId');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Property] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [Property] DROP COLUMN [PropertyFacilityId];

GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Property]') AND [c].[name] = N'PropertyFeatureId');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Property] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [Property] DROP COLUMN [PropertyFeatureId];

GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Property]') AND [c].[name] = N'PropertyTypeId');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Property] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [Property] DROP COLUMN [PropertyTypeId];

GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Property]') AND [c].[name] = N'RentalStatusId');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Property] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [Property] DROP COLUMN [RentalStatusId];

GO

ALTER TABLE [Property] ADD [Status] nvarchar(max) NOT NULL DEFAULT N'';

GO

ALTER TABLE [Property] ADD [Type] nvarchar(max) NOT NULL DEFAULT N'';

GO

CREATE TABLE [PropertyFacility] (
    [Stove] bit NULL,
    [Refrigerator] bit NULL,
    [Dishwasher] bit NULL,
    [AirConditioner] bit NOT NULL,
    [Laundry] bit NULL,
    [BlindsCurtain] bit NULL,
    [Furniture] bit NOT NULL,
    [Tvinternet] bit NOT NULL,
    [CommonFacility] bit NOT NULL,
    [SecuritySystem] bit NOT NULL,
    [UtilityIncluded] bit NOT NULL,
    [FireAlarmSystem] bit NULL,
    [Others] nvarchar(max) NULL,
    [Notes] nvarchar(max) NULL,
    [PropertyId] int NOT NULL,
    CONSTRAINT [PK_PropertyFacility] PRIMARY KEY ([PropertyId]),
    CONSTRAINT [FK_PropertyFacility_Property_PropertyId] FOREIGN KEY ([PropertyId]) REFERENCES [Property] ([Id]) ON DELE
TE CASCADE
);

GO

CREATE TABLE [PropertyFeature] (
    [NumberOfBedrooms] int NOT NULL,
    [NumberOfBathrooms] int NOT NULL,
    [NumberOfLayers] int NOT NULL,
    [NumberOfParking] int NOT NULL,
    [BasementAvailable] bit NOT NULL,
    [TotalLivingArea] int NOT NULL,
    [IsShared] bit NOT NULL,
    [Notes] nvarchar(max) NULL,
    [PropertyId] int NOT NULL,
    CONSTRAINT [PK_PropertyFeature] PRIMARY KEY ([PropertyId]),
    CONSTRAINT [FK_PropertyFeature_Property_PropertyId] FOREIGN KEY ([PropertyId]) REFERENCES [Property] ([Id]) ON DELET
E CASCADE
);

GO

CREATE TABLE [PropertyImg] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Modified] datetime2 NOT NULL,
    [PropertyImgTitle] nvarchar(max) NULL,
    [PropertyImgCaption] nvarchar(max) NULL,
    [PropertyId] int NOT NULL,
    CONSTRAINT [PK_PropertyImg] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PropertyImg_Property_PropertyId] FOREIGN KEY ([PropertyId]) REFERENCES [Property] ([Id]) ON DELETE CA
SCADE
);

GO

CREATE TABLE [PropertyOwner] (
    [Id] int NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [Modified] datetime2 NOT NULL,
    [UserName] nvarchar(50) NOT NULL DEFAULT (('tba')),
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [ContactEmail] nvarchar(100) NOT NULL,
    [ContactTelephone1] nvarchar(25) NOT NULL,
    [ContactTelephone2] nvarchar(25) NULL,
    [OnlineAccess] bit NOT NULL,
    [UserAvartaImgUrl] nvarchar(100) NOT NULL DEFAULT (('default')),
    [IsActive] bit NOT NULL DEFAULT (((1))),
    [RoleId] int NULL,
    [Notes] nvarchar(max) NULL,
    CONSTRAINT [PK_PropertyOwner] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [OwnerProperty] (
    [PropertyId] int NOT NULL,
    [PropertyOwnerId] int NOT NULL,
    CONSTRAINT [PK_OwnerProperty] PRIMARY KEY ([PropertyId], [PropertyOwnerId]),
    CONSTRAINT [FK_OwnerProperty_Property] FOREIGN KEY ([PropertyId]) REFERENCES [Property] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_OwnerProperty_PropertyOwner] FOREIGN KEY ([PropertyOwnerId]) REFERENCES [PropertyOwner] ([Id]) ON DEL
ETE NO ACTION
);

GO

CREATE INDEX [IX_OwnerProperty_PropertyOwnerId] ON [OwnerProperty] ([PropertyOwnerId]);

GO

CREATE INDEX [IX_PropertyImg_PropertyId] ON [PropertyImg] ([PropertyId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190107230211_new', N'2.1.4-rtm-31024');

GO