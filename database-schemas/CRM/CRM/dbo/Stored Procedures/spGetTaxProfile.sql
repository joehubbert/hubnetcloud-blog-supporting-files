CREATE PROCEDURE [dbo].[spGetTaxProfile]
	@taxProfileId UNIQUEIDENTIFIER
AS

SELECT
[Tax Profile Id],
[Tax Profile],
[Tax Rate]
FROM [dbo].[vwTaxProfile]
WHERE [Tax Profile Id] = @taxProfileId