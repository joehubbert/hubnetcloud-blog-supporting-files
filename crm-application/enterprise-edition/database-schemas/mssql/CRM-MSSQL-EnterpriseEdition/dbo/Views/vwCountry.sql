CREATE VIEW [dbo].[vwCountry]
AS

SELECT
[CountryId] AS [Country Id],
[ISOCountryCode] AS [ISO Country Code],
[CountryName] AS [Country Name],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By]
FROM [dbo].[Country]