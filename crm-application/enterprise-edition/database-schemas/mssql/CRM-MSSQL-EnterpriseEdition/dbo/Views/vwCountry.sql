CREATE VIEW [dbo].[vwCountry]
AS

SELECT
[CountryId] AS [Country Id],
[ISO31661A2CountryCode] AS [ISO 3166-1 Alpha 2 Country Code],
[CountryEnglishName] AS [Country English Name],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[Country]