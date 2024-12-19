CREATE PROCEDURE [dbo].[spGetAllSalesRegionMember]
AS

SELECT
[Sales Region Member Id],
[Sales Region],
[Sales Region Member]
FROM [dbo].[vwSalesRegionMember]