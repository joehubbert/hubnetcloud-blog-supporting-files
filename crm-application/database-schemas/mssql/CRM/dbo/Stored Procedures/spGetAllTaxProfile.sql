CREATE PROCEDURE [dbo].[spGetAllTaxProfile]
AS

SELECT
[Tax Profile Id],
[Tax Profile],
[Tax Rate],
[Active Status]
FROM [dbo].[vwTaxProfile]