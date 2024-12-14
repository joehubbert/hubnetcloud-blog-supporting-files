CREATE PROCEDURE [dbo].[DeleteTaxProfile]
	@taxProfileId UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[TaxProfile]
WHERE [TaxProfileId] = @taxProfileId