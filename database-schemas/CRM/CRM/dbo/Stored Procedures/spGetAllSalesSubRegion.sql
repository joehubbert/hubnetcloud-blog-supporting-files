CREATE PROCEDURE [dbo].[spGetAllSalesSubRegion]
AS

SELECT
[Sales Sub Region Id],
[Sales Region],
[Sales Sub Region],
[Sales Sub Region Active Status]
FROM [dbo].[vwSalesSubRegion]