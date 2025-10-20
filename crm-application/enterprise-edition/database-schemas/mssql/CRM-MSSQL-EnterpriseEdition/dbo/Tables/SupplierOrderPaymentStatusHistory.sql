CREATE TABLE [dbo].[SupplierOrderPaymentStatusHistory]
(
	[SupplierOrderPaymentStatusHistoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[SupplierOrderPaymentId] UNIQUEIDENTIFIER NOT NULL,
	[SupplierOrderPaymentStatusId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_SupplierOrderPaymentStatusHistory_SupplierOrderPaymentId] FOREIGN KEY ([SupplierOrderPaymentId]) REFERENCES [dbo].[SupplierOrderPayment]([SupplierOrderPaymentId]),
	CONSTRAINT [FK_SupplierOrderPaymentStatusHistory_SupplierOrderPaymentStatusId] FOREIGN KEY ([SupplierOrderPaymentStatusId]) REFERENCES [dbo].[SupplierOrderPaymentStatus]([SupplierOrderPaymentStatusId])
)
GO

CREATE NONCLUSTERED INDEX [NCIX_SupplierOrderPaymentStatusHistory_SupplierOrderPaymentId]
ON [dbo].[SupplierOrderPaymentStatusHistory] ([SupplierOrderPaymentId])
GO

CREATE TRIGGER [TRG_UpdateSupplierOrderPaymentStatusHistory]
ON [dbo].[SupplierOrderPaymentStatusHistory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SupplierOrderPaymentStatusHistory]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[SupplierOrderPaymentStatusHistory] sopsh
    INNER JOIN 
        inserted i ON sopsh.[SupplierOrderPaymentStatusHistoryId] = i.[SupplierOrderPaymentStatusHistoryId];
END
GO