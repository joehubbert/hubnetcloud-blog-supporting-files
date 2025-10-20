CREATE TABLE [dbo].[Product]
(
	[ProductId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [ProductSubCategoryId] UNIQUEIDENTIFIER NOT NULL,
    [ProductName] NVARCHAR(50) NOT NULL,
    [ProductDescription] NVARCHAR(255) NULL,
    [ManufacturerId] UNIQUEIDENTIFIER NOT NULL,
    [ManufacturerPartNumber] NVARCHAR(50) NULL,
    [ProductCountryOfOriginId] UNIQUEIDENTIFIER NOT NULL,
    [ProductFamilyId] UNIQUEIDENTIFIER NULL,
    [WholesaleFlag] BIT NOT NULL,
    [WholesaleCartonFlag] BIT NOT NULL,
    [WholesaleCartonArea] DECIMAL(10, 2) NULL,
    [WholesaleCartonBarcode] NVARCHAR(50) NULL,
    [WholesaleUnitQuantityPerCarton] INT NULL,
    [WholesaleUnitQuantityPerPalletLevel] TINYINT NULL,
    [WholesaleTotalUnitQuantityPerPallet] INT NULL,
    [WholesaleUnitStackingHeightPerPallet] TINYINT NULL,
    [WholesaleCartonStockQuantityHeld] BIGINT NULL,
    [WholesaleCartonPackagingWeightKilogram] DECIMAL(5, 2) NULL,
    [WholesaleCartonTotalWeightKilogram] DECIMAL(5, 2) NULL,
    [WholesaleCartonHeightCentimeter] DECIMAL(5, 2) NULL,
    [WholesaleCartonWidthCentimeter] DECIMAL(5, 2) NULL,
    [WholesaleCartonDepthCentimeter] DECIMAL(5, 2) NULL,
    [WholesaleCartonVolumeCubicCentimeter] DECIMAL (12, 3) NULL,
    [WholesalePalletFlag] BIT NOT NULL,
    [WholesalePalletArea] DECIMAL(10, 2) NULL,
    [WholesalePalletBarcode] NVARCHAR(50) NULL,
    [WholesaleCartonQuantityPerPalletLevel] TINYINT NULL,
    [WholesaleTotalCartonQuantityPerPallet] INT NULL,
    [WholesaleCartonStackingHeightPerPallet] TINYINT NULL,
    [WholesalePalletHeightCentimeter] DECIMAL(5, 2) NULL,
    [WholesalePalletWidthCentimeter] DECIMAL(5, 2) NULL,
    [WholesalePalletDepthCentimeter] DECIMAL(5, 2) NULL,
    [WholesalePalletVolumeCubicCentimeter] DECIMAL(12, 3) NULL,
    [WholesalePalletWeightKilogram] DECIMAL(5, 2) NULL, 
    [WholesalePalletTotalHeightCentimeter] DECIMAL(5, 2) NULL,
    [WholesalePalletTotalVolumeCubicCentimeter] DECIMAL(12, 3) NULL,
    [WholesalePalletTotalWeightKilogram] DECIMAL(5, 2) NULL,
    [WholesaleDeliveryTypeId] UNIQUEIDENTIFIER NULL,
    [WholesaleReorderFlag] BIT NOT NULL,
    [UnitArea] DECIMAL(10, 2) NOT NULL,
    [UnitBarcode] NVARCHAR(50) NULL,
    [UnitPrice] MONEY NOT NULL,
    [UnitMinimumStockQuantity] INT NULL,
    [UnitStockQuantityHeld] INT NOT NULL,
    [UnitWeightKilogram] DECIMAL(5, 2) NOT NULL,
    [UnitHeightCentimeter] DECIMAL(5, 2) NOT NULL,
    [UnitWidthCentimeter] DECIMAL(5, 2) NOT NULL,
    [UnitDepthCentimeter] DECIMAL(5, 2) NOT NULL,
    [UnitVolumeCubicCentimeter] DECIMAL(12, 3) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
    [CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [FK_Product_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [dbo].[Manufacturer]([ManufacturerId]),
    CONSTRAINT [FK_Product_ProductCountryOfOriginId] FOREIGN KEY ([ProductCountryOfOriginId]) REFERENCES [dbo].[Country]([CountryId]),
    CONSTRAINT [FK_Product_ProductFamilyId] FOREIGN KEY ([ProductFamilyId]) REFERENCES [dbo].[ProductFamily]([ProductFamilyId]),
    CONSTRAINT [FK_Product_ProductSubCategoryId] FOREIGN KEY ([ProductSubCategoryId]) REFERENCES [dbo].[ProductSubCategory]([ProductSubCategoryId]),
    CONSTRAINT [FK_Product_WholesaleDeliveryTypeId] FOREIGN KEY ([WholesaleDeliveryTypeId]) REFERENCES [dbo].[WholesaleDeliveryType]([WholesaleDeliveryTypeId]),
    CONSTRAINT [CC_Product_UnitStockQuantityHeld] CHECK ([UnitStockQuantityHeld] >= 0),
    CONSTRAINT [CC_Product_UnitStock_Limit] CHECK ([UnitStockQuantityHeld] <= [WholesaleUnitQuantityPerCarton] * [WholesaleCartonStockQuantityHeld]),
    CONSTRAINT [UC_Product_ProductName_ManufacturerId] UNIQUE ([ProductName], [ManufacturerId])
)
GO

CREATE NONCLUSTERED INDEX [NCIX_Product_ProductSubCategoryId]
ON [dbo].[Product] ([ProductSubCategoryId])
GO

CREATE TRIGGER [TRG_UpdateProduct]
ON [dbo].[Product]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[Product]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[Product] p
    INNER JOIN 
        inserted i ON p.[ProductId] = i.[ProductId];
END
GO