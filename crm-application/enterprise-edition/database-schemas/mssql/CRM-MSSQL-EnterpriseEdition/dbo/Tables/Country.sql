CREATE TABLE [dbo].[Country]
(
	[CountryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[ISO31661A2CountryCode] NCHAR(2) NOT NULL,
	[CountryEnglishName] NVARCHAR(100) NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL
)
GO

CREATE UNIQUE INDEX [NCIX_Country_ISO31661A2CountryCode] ON [dbo].[Country] ([ISO31661A2CountryCode])
GO

CREATE TRIGGER [TRG_UpdateCountry]
ON [dbo].[Country]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[Country]
	SET 
		[ModifiedTimestampUTC] = GETUTCDATE(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[Country] c
	INNER JOIN 
		inserted i ON c.[CountryId] = i.[CountryId];
END