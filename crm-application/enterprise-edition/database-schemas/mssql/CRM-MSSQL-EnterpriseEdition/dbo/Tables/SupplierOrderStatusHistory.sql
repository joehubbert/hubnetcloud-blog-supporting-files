CREATE TABLE [dbo].[SupplierOrderStatusHistory]
(
	[SupplierOrderStatusHistoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[SupplierOrderId] UNIQUEIDENTIFIER NOT NULL,
	[SupplierOrderStatusId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [FK_SupplierOrderStatusHistory_SupplierOrderId] FOREIGN KEY ([SupplierOrderId]) REFERENCES [dbo].[SupplierOrder]([SupplierOrderId]),
    CONSTRAINT [FK_SupplierOrderStatusHistory_SupplierOrderStatusId] FOREIGN KEY ([SupplierOrderStatusId]) REFERENCES [dbo].[SupplierOrderStatus]([SupplierOrderStatusId])
)
GO

CREATE NONCLUSTERED INDEX [IX_SupplierOrderStatusHistory_SupplierOrderId]
ON [dbo].[SupplierOrderStatusHistory] ([SupplierOrderId])
GO

CREATE TRIGGER [TRG_UpdateSupplierOrderStatusHistory]
ON [dbo].[SupplierOrderStatusHistory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SupplierOrderStatusHistory]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[SupplierOrderStatusHistory] sosh
    INNER JOIN 
        inserted i ON sosh.[SupplierOrderStatusHistoryId] = i.[SupplierOrderStatusHistoryId];
END
GO