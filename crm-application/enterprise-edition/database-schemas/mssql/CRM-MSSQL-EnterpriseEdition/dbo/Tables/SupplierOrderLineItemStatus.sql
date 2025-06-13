CREATE TABLE [dbo].[SupplierOrderLineItemStatus]
(
	[SupplierOrderLineItemStatusId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[SupplierOrderLineItemStatus] NVARCHAR(50) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [UC_SupplierOrderLineItemStatus_SupplierOrderLineItemStatus] UNIQUE ([SupplierOrderLineItemStatus])
)
GO

CREATE TRIGGER [TRG_UpdateSupplierOrderLineItemStatus]
ON [dbo].[SupplierOrderLineItemStatus]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SupplierOrderLineItemStatus]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[SupplierOrderLineItemStatus] solis
    INNER JOIN 
        inserted i ON solis.[SupplierOrderLineItemStatusId] = i.[SupplierOrderLineItemStatusId];
END
GO