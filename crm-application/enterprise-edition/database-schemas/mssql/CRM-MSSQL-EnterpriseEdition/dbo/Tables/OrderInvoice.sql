CREATE TABLE [dbo].[OrderInvoice]
(
	[OrderInvoiceId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[OrderId] UNIQUEIDENTIFIER NOT NULL,
	[OrderInvoice] VARBINARY(MAX) NOT NULL,
    [OrderInvoiceDate] DATE NOT NULL,
    [OrderInvoiceFriendlyId] NVARCHAR(30) NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [FK_OrderInvoice_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order]([OrderId]),
    CONSTRAINT [UC_OrderInvoice_OrderInvoiceFriendlyId] UNIQUE ([OrderInvoiceFriendlyId])
)
GO

CREATE NONCLUSTERED INDEX [IX_OrderInvoice_OrderId]
ON [dbo].[OrderInvoice] ([OrderId])
GO

CREATE TRIGGER [TRG_UpdateOrderInvoice]
ON [dbo].[OrderInvoice]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[OrderInvoice]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[OrderInvoice] oi
    INNER JOIN 
        inserted i ON oi.[OrderInvoiceId] = i.[OrderInvoiceId];
END
GO