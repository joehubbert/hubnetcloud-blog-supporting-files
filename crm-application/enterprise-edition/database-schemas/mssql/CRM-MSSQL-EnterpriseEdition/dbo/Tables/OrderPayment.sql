CREATE TABLE [dbo].[OrderPayment]
(
	[OrderPaymentId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[OrderId] UNIQUEIDENTIFIER NOT NULL,
	[PaymentMethodId] UNIQUEIDENTIFIER NOT NULL,
    [PaymentAmount] MONEY NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_OrderPayment_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order]([OrderId])
)
GO

CREATE TRIGGER [TRG_UpdateOrderPayment]
ON [dbo].[OrderPayment]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[OrderPayment]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[OrderPayment] op
    INNER JOIN 
        inserted i ON op.[OrderPaymentId] = i.[OrderPaymentId];
END
GO