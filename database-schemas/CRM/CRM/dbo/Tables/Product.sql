CREATE TABLE [dbo].[Product]
(
	[ProductId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [ProductCategoryId] UNIQUEIDENTIFIER NOT NULL, 
    [SupplierId] UNIQUEIDENTIFIER NOT NULL,
    [ProductName] NVARCHAR(50) NOT NULL, 
    [PurchasePricePerUnit] MONEY NOT NULL, 
    [UnitPrice] MONEY NOT NULL, 
    [ActiveStatus] BIT NOT NULL,
    [CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [FK_Product_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [dbo].[ProductCategory]([ProductCategoryId])
)
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