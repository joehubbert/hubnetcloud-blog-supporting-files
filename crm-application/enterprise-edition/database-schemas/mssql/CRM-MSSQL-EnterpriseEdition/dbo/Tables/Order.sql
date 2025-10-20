CREATE TABLE [dbo].[Order]
(
	[OrderId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [CustomerId] UNIQUEIDENTIFIER NOT NULL,
    [OrderTypeId] UNIQUEIDENTIFIER NOT NULL,
    [OrderDate] DATE NOT NULL,
    [OrderFriendlyId] NVARCHAR(20) NOT NULL,
    [PurchaseOrderNumber] NVARCHAR(50) NULL,
    [InternalReference] NVARCHAR(50) NULL,
    [CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [FK_Order_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([CustomerId]),
    CONSTRAINT [FK_Order_OrderTypeId] FOREIGN KEY ([OrderTypeId]) REFERENCES [dbo].[OrderType]([OrderTypeId]),
    CONSTRAINT [UC_Order_OrderFriendlyId] UNIQUE ([OrderFriendlyId])
)
GO

CREATE TRIGGER [TRG_UpdateOrder]
ON [dbo].[Order]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[Order]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[Order] o
    INNER JOIN 
        inserted i ON o.[OrderId] = i.[OrderId];
END
GO