CREATE TABLE [dbo].[ProductSupplier]
(
	[ProductSupplierId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[SupplierId] UNIQUEIDENTIFIER NOT NULL,
	[WholesalePricePerUnit] MONEY NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_ProductSupplier_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([ProductId]),
	CONSTRAINT [FK_ProductSupplier_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier]([SupplierId]),
	CONSTRAINT [UC_ProductSupplier_ProductId_SupplierId] UNIQUE ([ProductId], [SupplierId])
)
GO

CREATE INDEX [IX_ProductSupplier_SupplierId] ON [dbo].[ProductSupplier] ([SupplierId])
GO

CREATE INDEX [IX_ProductSupplier_ProductId] ON [dbo].[ProductSupplier] ([ProductId])
GO

CREATE TRIGGER [TRG_UpdateProductSupplier]
ON [dbo].[ProductSupplier]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[ProductSupplier]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[ProductSupplier] ps
    INNER JOIN 
        inserted i ON ps.[ProductSupplierId] = i.[ProductSupplierId];
END
GO