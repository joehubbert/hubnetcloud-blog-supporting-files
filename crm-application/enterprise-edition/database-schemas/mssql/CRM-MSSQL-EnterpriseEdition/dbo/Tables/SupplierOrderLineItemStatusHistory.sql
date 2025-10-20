CREATE TABLE [dbo].[SupplierOrderLineItemStatusHistory]
(
	[SupplierOrderLineItemStatusHistoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[SupplierOrderLineItemId] UNIQUEIDENTIFIER NOT NULL,
	[SupplierOrderLineItemStatusId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_SupplierOrderLineItemStatusHistory_SupplierOrderLineItemId] FOREIGN KEY ([SupplierOrderLineItemId]) REFERENCES [dbo].[SupplierOrderLineItem]([SupplierOrderLineItemId]),
	CONSTRAINT [FK_SupplierOrderLineItemStatusHistory_SupplierOrderLineItemStatusId] FOREIGN KEY ([SupplierOrderLineItemStatusId]) REFERENCES [dbo].[SupplierOrderLineItemStatus]([SupplierOrderLineItemStatusId])
)
GO

CREATE NONCLUSTERED INDEX [NCIX_SupplierOrderLineItemStatusHistory_SupplierOrderLineItemId]
ON [dbo].[SupplierOrderLineItemStatusHistory] ([SupplierOrderLineItemId])
GO

CREATE TRIGGER [TRG_UpdateSupplierOrderlineItemStatusHistory]
ON [dbo].[SupplierOrderLineItemStatusHistory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SupplierOrderLineItemStatusHistory]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[SupplierOrderLineItemStatusHistory] solish
    INNER JOIN 
        inserted i ON solish.[SupplierOrderLineItemStatusHistoryId] = i.[SupplierOrderLineItemStatusHistoryId];
END
GO