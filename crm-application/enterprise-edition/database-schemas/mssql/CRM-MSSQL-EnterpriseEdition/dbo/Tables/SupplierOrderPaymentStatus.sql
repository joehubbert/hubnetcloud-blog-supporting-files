CREATE TABLE [dbo].[SupplierOrderPaymentStatus]
(
	[SupplierOrderPaymentStatusId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[SupplierOrderPaymentStatus] NVARCHAR(50) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [UC_SupplierOrderPaymentStatus_SupplierOrderPaymentStatus] UNIQUE ([SupplierOrderPaymentStatus])
)
GO

CREATE TRIGGER [TRG_UpdateSupplierOrderPaymentStatus]
ON [dbo].[SupplierOrderPaymentStatus]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SupplierOrderPaymentStatus]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[SupplierOrderPaymentStatus] sops
    INNER JOIN 
        inserted i ON sops.[SupplierOrderPaymentStatusId] = i.[SupplierOrderPaymentStatusId];
END
GO