CREATE TABLE [dbo].[OrderLineItem]
(
	[OrderLineItemId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[OrderId] UNIQUEIDENTIFIER NOT NULL,
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[Quantity] INT NOT NULL,
	[TaxProfileId] UNIQUEIDENTIFIER NOT NULL,
	[PercentageDiscount] AS 
		CASE 
			WHEN [Quantity] > 500 THEN 0.2
			WHEN [Quantity] > 200 THEN 0.15
			WHEN [Quantity] > 150 THEN 0.1
			WHEN [Quantity] > 50 THEN 0.05
			ELSE 0.00
		END,
	CONSTRAINT [FK_OrderLineItem_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order]([OrderId]),
	CONSTRAINT [FK_OrderLineItem_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([ProductId]),
	CONSTRAINT [FK_OrderLineItem_TaxProfileId] FOREIGN KEY ([TaxProfileId]) REFERENCES [dbo].[TaxProfile]([TaxProfileId])
)