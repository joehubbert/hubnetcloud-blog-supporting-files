CREATE TABLE [dbo].[OrderLineItem]
(
	[OrderLineItemId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[OrderId] UNIQUEIDENTIFIER NOT NULL,
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[Quantity] INT NOT NULL,
	[UnitPrice] MONEY NOT NULL,
	[FinalPrice] MONEY NOT NULL,
	[TaxAmount] MONEY NOT NULL,
	[LineItemTotal] MONEY NOT NULL,
	[TaxProfileId] UNIQUEIDENTIFIER NOT NULL,
	[PercentageDiscount] DECIMAL(5,2) NOT NULL,
	[PromotionId] UNIQUEIDENTIFIER NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_OrderLineItem_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order]([OrderId]),
	CONSTRAINT [FK_OrderLineItem_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([ProductId]),
	CONSTRAINT [FK_OrderLineItem_PromotionId] FOREIGN KEY ([PromotionId]) REFERENCES [dbo].[Promotion]([PromotionId]),
	CONSTRAINT [FK_OrderLineItem_TaxProfileId] FOREIGN KEY ([TaxProfileId]) REFERENCES [dbo].[TaxProfile]([TaxProfileId]),
	CONSTRAINT [UC_OrderLineItem_OrderId_ProductId] UNIQUE ([OrderId], [ProductId])
)
GO

CREATE NONCLUSTERED INDEX [NCIX_OrderLineItem_OrderId_ProductId]
ON [dbo].[OrderLineItem] ([OrderId], [ProductId])
GO

CREATE TRIGGER [TRG_UpdateOrderLineItem]
ON [dbo].[OrderLineItem]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[OrderLineItem]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[OrderLineItem] oli
    INNER JOIN 
        inserted i ON oli.[OrderLineItemId] = i.[OrderLineItemId];
END
GO