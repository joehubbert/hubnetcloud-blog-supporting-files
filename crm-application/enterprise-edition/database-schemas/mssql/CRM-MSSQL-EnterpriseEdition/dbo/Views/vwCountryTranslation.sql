CREATE VIEW [dbo].[vwCountryTranslation]
AS

SELECT
CT.[CountryTranslationId] AS [Country Translation Id],
CT.[BCP47LanguageTagCode] AS [BCP 47 Language Tag Code],
CT.[LocalisedCountryName] AS [Localised Country Name],
C.[CountryId] AS [Country Id],
C.[CountryEnglishName] AS [Country English Name],
CT.[ActiveStatus] AS [Active Status],
CT.[CreatedTimestampUTC] AS [Created Timestamp UTC],
CT.[CreatedBy] AS [Created By],
CT.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
CT.[ModifiedBy] AS [Modified By]
FROM [dbo].[CountryTranslation] CT
INNER JOIN [dbo].[Country] C ON CT.[CountryId] = C.[CountryId]