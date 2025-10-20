CREATE TABLE [dbo].[SupplierOrderLineItem]
(
	[SupplierOrderLineItemId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[SupplierOrderId] UNIQUEIDENTIFIER NOT NULL,
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[WholesaleCartonQuantity] INT NOT NULL,
	[WholesalePricePerUnit] MONEY NOT NULL,
	[LineItemTotal] MONEY NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_SupplierOrderLineItem_OrderId] FOREIGN KEY ([SupplierOrderId]) REFERENCES [dbo].[SupplierOrder]([SupplierOrderId]),
	CONSTRAINT [FK_SupplierOrderLineItem_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([ProductId]),
	CONSTRAINT [UC_SupplierOrderLineItem_SupplierOrderId_ProductId] UNIQUE ([SupplierOrderId], [ProductId])
)
GO

CREATE NONCLUSTERED INDEX [NCIX_SupplierOrderLineItem_OrderId_ProductId]
ON [dbo].[SupplierOrderLineItem] ([SupplierOrderId], [ProductId])
GO

CREATE TRIGGER [TRG_UpdateSupplierOrderLineItem]
ON [dbo].[SupplierOrderLineItem]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SupplierOrderLineItem]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[SupplierOrderLineItem] soli
    INNER JOIN 
        inserted i ON soli.[SupplierOrderLineItemId] = i.[SupplierOrderLineItemId];
END
GO