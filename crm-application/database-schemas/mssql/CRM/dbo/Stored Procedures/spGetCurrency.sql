CREATE PROCEDURE [dbo].[spGetCurrency]
	@currencyId UNIQUEIDENTIFIER
AS

SELECT
[Currency Id],
[Currency Code],
[Currency Name],
[Active Status],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwCurrency]
WHERE [Currency Id] = @currencyId