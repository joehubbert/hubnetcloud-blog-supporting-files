CREATE TABLE [dbo].[OrderStatusHistory]
(
	[OrderStatusHistoryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[OrderId] UNIQUEIDENTIFIER NOT NULL,
	[OrderStatusId] UNIQUEIDENTIFIER NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [FK_OrderStatusHistory_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order]([OrderId]),
    CONSTRAINT [FK_OrderStatusHistory_OrderStatusId] FOREIGN KEY ([OrderStatusId]) REFERENCES [dbo].[OrderStatus]([OrderStatusId])
)
GO

CREATE NONCLUSTERED INDEX [NCIX_OrderStatusHistory_OrderId]
ON [dbo].[OrderStatusHistory] ([OrderId])
GO

CREATE TRIGGER [TRG_UpdateOrderStatusHistory]
ON [dbo].[OrderStatusHistory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[OrderStatusHistory]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[OrderStatusHistory] osh
    INNER JOIN 
        inserted i ON osh.[OrderStatusHistoryId] = i.[OrderStatusHistoryId];
END
GO