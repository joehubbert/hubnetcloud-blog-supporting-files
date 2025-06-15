CREATE TABLE [dbo].[OrderLineItemStatusHistory]
(
	[OrderLineItemStatusHistoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[OrderLineItemId] UNIQUEIDENTIFIER NOT NULL,
	[OrderLineItemStatusId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_OrderLineItemStatusHistory_OrderLineItemId] FOREIGN KEY ([OrderLineItemId]) REFERENCES [dbo].[OrderLineItem]([OrderLineItemId]),
	CONSTRAINT [FK_OrderLineItemStatusHistory_OrderLineItemStatusId] FOREIGN KEY ([OrderLineItemStatusId]) REFERENCES [dbo].[OrderLineItemStatus]([OrderLineItemStatusId])
)
GO

CREATE NONCLUSTERED INDEX [IX_OrderLineItemStatusHistory_OrderLineItemId]
ON [dbo].[OrderLineItemStatusHistory] ([OrderLineItemId])
GO

CREATE TRIGGER [TRG_UpdateOrderlineItemStatusHistory]
ON [dbo].[OrderLineItemStatusHistory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[OrderLineItemStatusHistory]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[OrderLineItemStatusHistory] olish
    INNER JOIN 
        inserted i ON olish.[OrderLineItemStatusHistoryId] = i.[OrderLineItemStatusHistoryId];
END
GO