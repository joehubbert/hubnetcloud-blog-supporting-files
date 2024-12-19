CREATE PROCEDURE [dbo].[spGetTaxProfile]
	@taxProfileId UNIQUEIDENTIFIER
AS

SELECT
[Tax Profile Id],
[Tax Profile],
[Tax Rate],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwTaxProfile]
WHERE [Tax Profile Id] = @taxProfileId