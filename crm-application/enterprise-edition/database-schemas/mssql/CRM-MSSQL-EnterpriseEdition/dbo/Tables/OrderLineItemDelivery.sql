CREATE TABLE [dbo].[OrderLineItemDelivery]
(
	[OrderLineItemDeliveryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[OrderLineItemId] UNIQUEIDENTIFIER NOT NULL,
	[DeliveryMethodId] UNIQUEIDENTIFIER NOT NULL,
	[ShippingDate] DATE NOT NULL,
	[DeliveryDate] DATE NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_OrderDelivery_OrderLineItemId] FOREIGN KEY ([OrderLineItemId]) REFERENCES [dbo].[OrderLineItem]([OrderLineItemId]),
	CONSTRAINT [FK_OrderDelivery_DeliveryMethodId] FOREIGN KEY ([DeliveryMethodId]) REFERENCES [dbo].[DeliveryMethod]([DeliveryMethodId]),
	CONSTRAINT [UC_OrderDelivery_OrderLineItemId] UNIQUE ([OrderLineItemId])
)
GO

CREATE NONCLUSTERED INDEX [NCIX_OrderLineItemDelivery_DeliveryDate]
ON [dbo].[OrderLineItemDelivery] ([DeliveryDate])
GO

CREATE TRIGGER [TRG_UpdateOrderLineItemDelivery]
ON [dbo].[OrderLineItemDelivery]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[OrderLineItemDelivery]
	SET 
		[ModifiedTimestampUTC] = GETUTCDATE(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[OrderLineItemDelivery] OLID
	INNER JOIN 
		inserted i ON OLID.[OrderLineItemDeliveryId] = i.[OrderLineItemDeliveryId]
END
GO