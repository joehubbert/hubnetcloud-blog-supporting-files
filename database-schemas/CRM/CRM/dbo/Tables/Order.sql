CREATE TABLE [dbo].[Order]
(
	[OrderId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [CustomerId] UNIQUEIDENTIFIER NOT NULL, 
    [OrderStatusId] UNIQUEIDENTIFIER NOT NULL,
    [PaymentMethodId] UNIQUEIDENTIFIER NOT NULL,
    [CurrencyId] UNIQUEIDENTIFIER NOT NULL,
    [CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [FK_Order_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([CustomerId]),
    CONSTRAINT [FK_Order_OrderStatusId] FOREIGN KEY ([OrderStatusId]) REFERENCES [dbo].[OrderStatus]([OrderStatusId]),
    CONSTRAINT [FK_Order_PaymentMethodId] FOREIGN KEY ([PaymentMethodId]) REFERENCES [dbo].[PaymentMethod]([PaymentMethodId]),
    CONSTRAINT [FK_Order_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currency]([CurrencyId])
)
GO

CREATE TRIGGER [TRG_UpdateOrder]
ON [dbo].[Order]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[Order]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[Order] o
    INNER JOIN 
        inserted i ON o.[OrderId] = i.[OrderId];
END
GO