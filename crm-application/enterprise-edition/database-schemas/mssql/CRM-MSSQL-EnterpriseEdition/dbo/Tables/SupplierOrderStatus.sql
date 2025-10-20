CREATE TABLE [dbo].[SupplierOrderStatus]
(
	[SupplierOrderStatusId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[SupplierOrderStatus] NVARCHAR(50) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [UC_SupplierOrderStatus_SupplierOrderStatus] UNIQUE ([SupplierOrderStatus])
)
GO

CREATE TRIGGER [TRG_UpdateSupplierOrderStatus]
ON [dbo].[SupplierOrderStatus]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SupplierOrderStatus]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[SupplierOrderStatus] sos
    INNER JOIN 
        inserted i ON sos.[SupplierOrderStatusId] = i.[SupplierOrderStatusId];
END
GO