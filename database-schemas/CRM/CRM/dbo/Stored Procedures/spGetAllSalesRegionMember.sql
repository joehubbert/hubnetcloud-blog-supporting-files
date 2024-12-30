CREATE PROCEDURE [dbo].[spGetAllSalesRegionMember]
AS

SELECT
[Sales Region Member Id],
[Sales Region],
[Sales Region Member],
[Sales Region Member Active Status]
FROM [dbo].[vwSalesRegionMember]