CREATE PROCEDURE [dbo].[spGetAllCurrency]
AS

SELECT
[CurrencyId] AS [Currency Id],
[CurrencyCode] AS [Currency Code],
[CurrencyName] AS [Currency Name],
[ActiveStatus] AS [Active Status]
FROM [dbo].[Currency]