CREATE PROCEDURE [dbo].[spUpdateTaxProfile]
	@taxProfile NVARCHAR(50),
	@taxProfileId UNIQUEIDENTIFIER,
	@taxRate DECIMAL(5, 2)
AS

UPDATE [dbo].[TaxProfile]
SET 
	[TaxProfile] = @taxProfile,
	[TaxRate] = @taxRate
WHERE [TaxProfileId] = @taxProfileId