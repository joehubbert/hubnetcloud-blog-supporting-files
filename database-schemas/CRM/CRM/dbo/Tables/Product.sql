CREATE TABLE [dbo].[Product]
(
	[ProductId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [ProductCategoryId] UNIQUEIDENTIFIER NOT NULL, 
    [SupplierId] UNIQUEIDENTIFIER NOT NULL,
    [ProductName] NVARCHAR(50) NOT NULL, 
    [PurchasePricePerUnit] MONEY NOT NULL, 
    [UnitPrice] MONEY NOT NULL, 
    [ActiveStatus] BIT NOT NULL,
    CONSTRAINT [FK_Product_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [dbo].[ProductCategory]([ProductCategoryId])
)