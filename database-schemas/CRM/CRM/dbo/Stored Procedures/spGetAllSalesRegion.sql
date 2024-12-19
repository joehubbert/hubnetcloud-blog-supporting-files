CREATE PROCEDURE [dbo].[spGetAllSalesRegion]
AS

SELECT
[Sales Region Id],
[Sales Region]
FROM [dbo].[vwSalesRegion]