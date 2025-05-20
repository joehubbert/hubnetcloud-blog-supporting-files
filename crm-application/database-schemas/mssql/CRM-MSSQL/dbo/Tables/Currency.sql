CREATE TABLE [dbo].[Currency]
(
	[CurrencyId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CurrencyCode] NCHAR(3) NOT NULL,
	[CurrencyName] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [UC_CurrencyCode] UNIQUE ([CurrencyCode])
)
GO

CREATE TRIGGER [TRG_UpdateCurrency]
ON [dbo].[Currency]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[Currency]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[Currency] c
    INNER JOIN 
        inserted i ON c.[CurrencyId] = i.[CurrencyId];
END
GO