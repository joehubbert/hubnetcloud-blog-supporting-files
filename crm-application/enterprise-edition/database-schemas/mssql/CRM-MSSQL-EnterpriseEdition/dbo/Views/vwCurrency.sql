CREATE VIEW [dbo].[vwCurrency]
AS
SELECT
[CurrencyId] AS [Currency Id],
[CurrencyCode] AS [Currency Code],
[CurrencyName] AS [Currency Name],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[Currency]