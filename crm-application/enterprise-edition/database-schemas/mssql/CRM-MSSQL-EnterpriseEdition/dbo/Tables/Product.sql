CREATE TABLE [dbo].[Product]
(
	[ProductId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [ProductSubCategoryId] UNIQUEIDENTIFIER NOT NULL,
    [ProductName] NVARCHAR(50) NOT NULL,
    [ManufacturerId] UNIQUEIDENTIFIER NOT NULL,
    [ProductImage] VARBINARY(MAX) NULL,
    [WholesaleUnitQuantityPerCarton] INT NOT NULL,
    [WholesaleCartonStockQuantityHeld] INT NOT NULL,
    [WholesaleReorderFlag] BIT NOT NULL,
    [UnitPrice] MONEY NOT NULL,
    [UnitMinimumOrderQuantity] INT NOT NULL,
    [UnitMinimumStockQuantity] INT NOT NULL,
    [UnitStockQuantityHeld] INT NOT NULL,
    [ActiveStatus] BIT NOT NULL,
    [CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [FK_Product_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [dbo].[Manufacturer]([ManufacturerId]),
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
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[Product] p
    INNER JOIN 
        inserted i ON p.[ProductId] = i.[ProductId];
END
GO