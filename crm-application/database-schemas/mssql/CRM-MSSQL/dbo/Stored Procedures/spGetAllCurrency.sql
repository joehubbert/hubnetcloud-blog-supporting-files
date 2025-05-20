CREATE PROCEDURE [dbo].[spGetAllCurrency]
AS

SELECT
[Currency Id],
[Currency Code],
[Currency Name],
[Active Status]
FROM [dbo].[vwCurrency]