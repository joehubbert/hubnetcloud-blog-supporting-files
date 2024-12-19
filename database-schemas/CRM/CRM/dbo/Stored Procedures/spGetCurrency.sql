CREATE PROCEDURE [dbo].[spGetCurrency]
	@currencyId UNIQUEIDENTIFIER
AS

SELECT
[CurrencyId] AS [Currency Id],
[CurrencyCode] AS [Currency Code],
[CurrencyName] AS [Currency Name],
[ActiveStatus] AS [Active Status]
FROM [dbo].[Currency]
WHERE [CurrencyId] = @currencyId