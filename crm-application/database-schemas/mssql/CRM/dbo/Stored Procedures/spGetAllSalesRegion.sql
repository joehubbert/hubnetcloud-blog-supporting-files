CREATE PROCEDURE [dbo].[spGetAllSalesRegion]
AS

SELECT
[Sales Region Id],
[Sales Region],
[Active Status]
FROM [dbo].[vwSalesRegion]