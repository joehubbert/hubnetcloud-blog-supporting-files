CREATE VIEW [dbo].[vwCurrency]
AS
SELECT
[CurrencyId] AS [Currency Id],
[CurrencyCode] AS [Currency Code],
[CurrencyName] AS [Currency Name],
[ActiveStatus] AS [Active Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[Currency]