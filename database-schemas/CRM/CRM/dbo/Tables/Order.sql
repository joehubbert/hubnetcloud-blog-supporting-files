CREATE TABLE [dbo].[Order]
(
	[OrderId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [CustomerId] UNIQUEIDENTIFIER NOT NULL, 
    [OrderStatusId] UNIQUEIDENTIFIER NOT NULL,
    [DeliveryMethodId] UNIQUEIDENTIFIER NOT NULL,
    [PaymentMethodId] UNIQUEIDENTIFIER NOT NULL,
    [CreditUsed] BIT NOT NULL,
    CONSTRAINT [FK_Order_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([CustomerId]),
    CONSTRAINT [FK_Order_OrderStatusId] FOREIGN KEY ([OrderStatusId]) REFERENCES [dbo].[OrderStatus]([OrderStatusId]),
    CONSTRAINT [FK_Order_DeliveryMethodId] FOREIGN KEY ([DeliveryMethodId]) REFERENCES [dbo].[DeliveryMethod]([DeliveryMethodId]),
    CONSTRAINT [FK_Order_PaymentMethodId] FOREIGN KEY ([PaymentMethodId]) REFERENCES [dbo].[PaymentMethod]([PaymentMethodId])
)