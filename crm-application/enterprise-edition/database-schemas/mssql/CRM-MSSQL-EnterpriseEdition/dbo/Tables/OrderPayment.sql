CREATE TABLE [dbo].[OrderPayment]
(
	[OrderPaymentId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[OrderId] UNIQUEIDENTIFIER NOT NULL,
	[PaymentMethodId] UNIQUEIDENTIFIER NOT NULL,
    [PaymentAmount] MONEY NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [FK_OrderPayment_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order]([OrderId]),
    CONSTRAINT [FK_OrderPayment_PaymentMethodId] FOREIGN KEY ([PaymentMethodId]) REFERENCES [dbo].[PaymentMethod]([PaymentMethodId])
)
GO

CREATE TRIGGER [TRG_CheckOrderPaymentValidOrderType]
ON [dbo].[OrderPayment]
AFTER INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN [dbo].[Order] o ON o.[OrderId] = i.[OrderId]
        INNER JOIN [dbo].[OrderType] ot ON ot.[OrderTypeId] = o.[OrderTypeId]
        WHERE ot.[OrderType] = 'Final' -- assuming [OrderType] is a string like 'Final'
    )
    BEGIN
        RAISERROR('Payments can only be added to orders with OrderType = Final.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END
GO

CREATE TRIGGER [TRG_UpdateOrderPayment]
ON [dbo].[OrderPayment]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[OrderPayment]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[OrderPayment] op
    INNER JOIN 
        inserted i ON op.[OrderPaymentId] = i.[OrderPaymentId];
END
GO