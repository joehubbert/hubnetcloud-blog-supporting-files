CREATE TABLE [dbo].[OrderDelivery]
(
	[OrderDeliveryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[OrderId] UNIQUEIDENTIFIER NOT NULL,
	[DeliveryMethodId] UNIQUEIDENTIFIER NOT NULL,
	[ShippingDate] DATE NOT NULL,
	[DeliveryDate] DATE NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_OrderDelivery_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order]([OrderId]),
	CONSTRAINT [FK_OrderDelivery_DeliveryMethodId] FOREIGN KEY ([DeliveryMethodId]) REFERENCES [dbo].[DeliveryMethod]([DeliveryMethodId]),
	CONSTRAINT [UC_OrderDelivery_OrderId] UNIQUE ([OrderId])
)
GO

CREATE TRIGGER [TRG_UpdateOrderDelivery]
ON [dbo].[OrderDelivery]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[OrderDelivery]
	SET 
		[ModifiedTimestamp] = GETUTCDATE(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[OrderDelivery] OD
	INNER JOIN 
		inserted i ON OD.[OrderDeliveryId] = i.[OrderDeliveryId]
END
GO