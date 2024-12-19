CREATE PROCEDURE [dbo].[spGetAllTaxProfile]
AS

SELECT
[Tax Profile Id],
[Tax Profile],
[Tax Rate]
FROM [dbo].[vwTaxProfile]