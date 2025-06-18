CREATE TABLE [dbo].[CountryTranslation]
(
	[CountryTranslationId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CountryId] UNIQUEIDENTIFIER NOT NULL,
	[BCP47LanguageTagCode] NVARCHAR(5) NOT NULL,
	[LocalisedCountryName] NVARCHAR(100) NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_CountryTranslation_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country]([CountryId]),
	CONSTRAINT [UC_CountryTranslation_CountryId_BCP47LanguageTagCode] UNIQUE ([CountryId], [BCP47LanguageTagCode])
)
GO

CREATE TRIGGER [TRG_UpdateCountryTranslation]
ON [dbo].[CountryTranslation]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[CountryTranslation]
	SET 
		[ModifiedTimestampUTC] = GETUTCDATE(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[CountryTranslation] ct
	INNER JOIN 
		inserted i ON ct.[CountryTranslationId] = i.[CountryTranslationId];
END