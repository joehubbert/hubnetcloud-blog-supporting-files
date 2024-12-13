CREATE TABLE [dbo].[CustomerTier]
(
	[CustomerTierId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CustomerTierCode] NCHAR(1) NOT NULL,
	[CustomerTierDescription] NVARCHAR(50) NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL
)
GO

CREATE TRIGGER [TRG_UpdateCustomerTier]
ON [dbo].[CustomerTier]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[CustomerTier]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[CustomerTier] ct
    INNER JOIN 
        inserted i ON ct.[CustomerTierId] = i.[CustomerTierId];
END
GO