CREATE PROCEDURE [dbo].[spGetTaxProfile]
	@taxProfileId UNIQUEIDENTIFIER
AS

SELECT
[TaxProfileId] AS [Tax Profile Id],
[TaxProfile] AS [Tax Profile],
[TaxRate] AS [Tax Rate]
FROM [dbo].[TaxProfile]
WHERE [TaxProfileId] = @taxProfileId