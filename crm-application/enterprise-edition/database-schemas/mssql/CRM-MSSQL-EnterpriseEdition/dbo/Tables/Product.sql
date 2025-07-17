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
    [WholesaleCartonBarcode] NVARCHAR(50) NULL,
    [WholesaleUnitQuantityPerCarton] INT NOT NULL,
    [WholesaleCartonStockQuantityHeld] INT NOT NULL,
    [WholesaleCartonWeightKilogram] DECIMAL(5, 2) NOT NULL,
    [WholesaleCartonHeightCentimeter] DECIMAL(5, 2) NOT NULL,
    [WholesaleCartonWidthCentimeter] DECIMAL(5, 2) NOT NULL,
    [WholesaleCartonDepthCentimeter] DECIMAL(5, 2) NOT NULL,
    [WholesaleReorderFlag] BIT NOT NULL,
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