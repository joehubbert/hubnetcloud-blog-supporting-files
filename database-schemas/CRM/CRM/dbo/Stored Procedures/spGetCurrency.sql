CREATE PROCEDURE [dbo].[spGetCurrency]
	@currencyId UNIQUEIDENTIFIER
AS

SELECT
[Currency Id],
[Currency Code],
[Currency Name],
[Active Status]
FROM [dbo].[vwCurrency]
WHERE [Currency Id] = @currencyId