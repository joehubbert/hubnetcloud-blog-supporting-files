CREATE PROCEDURE [dbo].[spGetAllTaxProfile]
AS

SELECT
[TaxProfileId] AS [Tax Profile Id],
[TaxProfile] AS [Tax Profile],
[TaxRate] AS [Tax Rate]
FROM [dbo].[TaxProfile]