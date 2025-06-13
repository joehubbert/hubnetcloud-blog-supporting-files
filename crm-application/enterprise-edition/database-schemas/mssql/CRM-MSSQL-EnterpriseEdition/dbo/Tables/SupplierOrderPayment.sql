CREATE TABLE [dbo].[SupplierOrderPayment]
(
	[SupplierOrderPaymentId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[SupplierOrderId] UNIQUEIDENTIFIER NOT NULL,
	[PaymentMethodId] UNIQUEIDENTIFIER NOT NULL,
    [PaymentAmount] MONEY NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_SupplierOrderPayment_SupplierOrderId] FOREIGN KEY ([SupplierOrderId]) REFERENCES [dbo].[SupplierOrder]([SupplierOrderId])
)
GO

CREATE TRIGGER [TRG_UpdateSupplierOrderPayment]
ON [dbo].[SupplierOrderPayment]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SupplierOrderPayment]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[SupplierOrderPayment] sop
    INNER JOIN 
        inserted i ON sop.[SupplierOrderPaymentId] = i.[SupplierOrderPaymentId];
END
GO