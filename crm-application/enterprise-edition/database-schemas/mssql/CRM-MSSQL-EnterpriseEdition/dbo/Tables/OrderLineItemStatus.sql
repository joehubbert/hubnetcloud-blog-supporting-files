CREATE TABLE [dbo].[OrderLineItemStatus]
(
	[OrderLineItemStatusId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[OrderLineItemStatus] NVARCHAR(50) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [UC_OrderLineItemStatus_OrderLineItemStatus] UNIQUE ([OrderLineItemStatus])
)
GO

CREATE TRIGGER [TRG_UpdateOrderLineItemStatus]
ON [dbo].[OrderLineItemStatus]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[OrderLineItemStatus]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[OrderLineItemStatus] olis
    INNER JOIN 
        inserted i ON olis.[OrderLineItemStatusId] = i.[OrderLineItemStatusId];
END
GO