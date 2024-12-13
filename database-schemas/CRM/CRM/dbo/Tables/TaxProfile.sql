CREATE TABLE [dbo].[TaxProfile]
(
	[TaxProfileId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[TaxProfile] NVARCHAR(50) NOT NULL,
	[TaxRate] DECIMAL(5, 2) NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL
)
GO

CREATE TRIGGER [TRG_UpdateTaxProfile]
ON [dbo].[TaxProfile]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[TaxProfile]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[TaxProfile] tp
    INNER JOIN 
        inserted i ON tp.[TaxProfileId] = i.[TaxProfileId];
END
GO