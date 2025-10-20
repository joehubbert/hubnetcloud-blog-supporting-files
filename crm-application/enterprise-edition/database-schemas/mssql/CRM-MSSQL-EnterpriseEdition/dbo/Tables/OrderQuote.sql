CREATE TABLE [dbo].[OrderQuote]
(
	[OrderQuoteId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[OrderId] UNIQUEIDENTIFIER NOT NULL,
	[OrderQuote] VARBINARY(MAX) NOT NULL,
    [OrderQuoteDate] DATE NOT NULL,
    [OrderQuoteFriendlyId] NVARCHAR(30) NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [FK_OrderQuote_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order]([OrderId]),
    CONSTRAINT [UC_OrderQuote_OrderQuoteFriendlyId] UNIQUE ([OrderQuoteFriendlyId])
)
GO

CREATE NONCLUSTERED INDEX [NCIX_OrderQuote_OrderId]
ON [dbo].[OrderQuote] ([OrderId])
GO

CREATE TRIGGER [TRG_UpdateOrderQuote]
ON [dbo].[OrderQuote]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[OrderQuote]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[OrderQuote] oq
    INNER JOIN 
        inserted i ON oq.[OrderQuoteId] = i.[OrderQuoteId];
END
GO