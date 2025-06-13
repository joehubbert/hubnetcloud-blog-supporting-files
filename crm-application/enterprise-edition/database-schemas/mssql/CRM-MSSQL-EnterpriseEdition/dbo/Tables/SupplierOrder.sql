CREATE TABLE [dbo].[SupplierOrder]
(
	[SupplierOrderId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [SupplierId] UNIQUEIDENTIFIER NOT NULL,
    [InternalReference] NVARCHAR(50) NULL,
    [CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [FK_SupplierOrder_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier]([SupplierId])
)
GO

CREATE TRIGGER [TRG_UpdateSupplierOrder]
ON [dbo].[SupplierOrder]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SupplierOrder]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[SupplierOrder] so
    INNER JOIN 
        inserted i ON so.[SupplierOrderId] = i.[SupplierOrderId];
END
GO