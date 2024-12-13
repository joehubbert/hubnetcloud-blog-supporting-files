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
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_OrderLineItem_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order]([OrderId]),
	CONSTRAINT [FK_OrderLineItem_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([ProductId]),
	CONSTRAINT [FK_OrderLineItem_TaxProfileId] FOREIGN KEY ([TaxProfileId]) REFERENCES [dbo].[TaxProfile]([TaxProfileId])
)
GO

CREATE TRIGGER [TRG_UpdateOrderLineItem]
ON [dbo].[OrderLineItem]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[OrderLineItem]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[OrderLineItem] oli
    INNER JOIN 
        inserted i ON oli.[OrderLineItemId] = i.[OrderLineItemId];
END
GO