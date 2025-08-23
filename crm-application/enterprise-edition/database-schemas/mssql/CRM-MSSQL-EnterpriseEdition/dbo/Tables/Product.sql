CREATE TABLE [dbo].[Product]
(
	[ProductId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [ProductSubCategoryId] UNIQUEIDENTIFIER NOT NULL,
    [ProductName] NVARCHAR(50) NOT NULL,
    [ProductDescription] NVARCHAR(255) NULL,
    [ManufacturerId] UNIQUEIDENTIFIER NOT NULL,
    [ManufacturerPartNumber] NVARCHAR(50) NULL,
    [ProductImage] VARBINARY(MAX) NULL,
    [ProductCountryOfOriginId] UNIQUEIDENTIFIER NULL,
    [ProductFamilyId] UNIQUEIDENTIFIER NULL,
    [WholesaleCartonFlag] BIT NOT NULL,
    [WholesaleCartonBarcode] NVARCHAR(50) NULL,
    [WholesaleUnitQuantityPerCarton] INT NULL,
    [WholesaleCartonStockQuantityHeld] BIGINT NULL,
    [WholesaleCartonWeightKilogram] DECIMAL(5, 2) NULL,
    [WholesaleCartonHeightCentimeter] DECIMAL(5, 2) NULL,
    [WholesaleCartonWidthCentimeter] DECIMAL(5, 2) NULL,
    [WholesaleCartonDepthCentimeter] DECIMAL(5, 2) NULL,
    [WholesalePalletFlag] BIT NOT NULL,
    [WholesaleCartonQuantityPerPallet] TINYINT NULL,
    [WholesalePalletHeightCentimeter] DECIMAL(5, 2) NULL,
    [WholesalePalletWidthCentimeter] DECIMAL(5, 2) NULL,
    [WholesalePalletDepthCentimeter] DECIMAL(5, 2) NULL,
    [WholesalePalletWeightKilogram] DECIMAL(5, 2) NULL,
    [WholesalePalletTotalHeightCentimeter] DECIMAL(5, 2) NULL,
    [WholesalePalletTotalWidthCentimeter] DECIMAL(5, 2) NULL,
    [WholesalePalletTotalDepthCentimeter] DECIMAL(5, 2) NULL,
    [WholesalePalletTotalWeightKilogram] DECIMAL(5, 2) NULL,
    [WholesaleReorderFlag] BIT NULL,
    [UnitBarcode] NVARCHAR(50) NULL,
    [UnitPrice] MONEY NOT NULL,
    [UnitMinimumOrderQuantity] INT NOT NULL,
    [UnitMinimumStockQuantity] INT NOT NULL,
    [UnitStockQuantityHeld] INT NOT NULL,
    [UnitWeightKilogram] DECIMAL(5, 2) NOT NULL,
    [UnitHeightCentimeter] DECIMAL(5, 2) NOT NULL,
    [UnitWidthCentimeter] DECIMAL(5, 2) NOT NULL,
    [UnitDepthCentimeter] DECIMAL(5, 2) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
    [CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [FK_Product_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [dbo].[Manufacturer]([ManufacturerId]),
    CONSTRAINT [FK_Product_ProductCountryOfOriginId] FOREIGN KEY ([ProductCountryOfOriginId]) REFERENCES [dbo].[Country]([CountryId]),
    CONSTRAINT [FK_Product_ProductFamilyId] FOREIGN KEY ([ProductFamilyId]) REFERENCES [dbo].[ProductFamily]([ProductFamilyId]),
    CONSTRAINT [FK_Product_ProductSubCategoryId] FOREIGN KEY ([ProductSubCategoryId]) REFERENCES [dbo].[ProductSubCategory]([ProductSubCategoryId]),
    CONSTRAINT [CC_Product_UnitStockQuantityHeld] CHECK ([UnitStockQuantityHeld] >= 0),
    CONSTRAINT [CC_Product_UnitStock_Limit] CHECK ([UnitStockQuantityHeld] <= [WholesaleUnitQuantityPerCarton] * [WholesaleCartonStockQuantityHeld]),
    CONSTRAINT [UC_Product_ProductName_ManufacturerId] UNIQUE ([ProductName], [ManufacturerId])
)
GO

CREATE NONCLUSTERED INDEX [IX_Product_ProductSubCategoryId]
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
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[Product] p
    INNER JOIN 
        inserted i ON p.[ProductId] = i.[ProductId];
END
GO