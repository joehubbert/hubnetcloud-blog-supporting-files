CREATE TABLE [dbo].[OrderLineItem]
(
	[OrderLineItemId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[OrderId] UNIQUEIDENTIFIER NOT NULL,
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[Quantity] INT NOT NULL,
	[TaxProfileId] UNIQUEIDENTIFIER NOT NULL,
	[PercentageDiscount] DECIMAL(5, 2) NOT NULL,
	CONSTRAINT [FK_OrderLineItem_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order]([OrderId]),
	CONSTRAINT [FK_OrderLineItem_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([ProductId]),
	CONSTRAINT [FK_OrderLineItem_TaxProfileId] FOREIGN KEY ([TaxProfileId]) REFERENCES [dbo].[TaxProfile]([TaxProfileId])
)