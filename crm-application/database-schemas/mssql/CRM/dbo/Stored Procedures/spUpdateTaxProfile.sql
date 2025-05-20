CREATE PROCEDURE [dbo].[spUpdateTaxProfile]
	@activeStatus BIT,
	@taxProfile NVARCHAR(50),
	@taxProfileId UNIQUEIDENTIFIER,
	@taxRate DECIMAL(5, 2)
AS

UPDATE [dbo].[TaxProfile]
SET 
	[ActiveStatus] = @activeStatus,
	[TaxProfile] = @taxProfile,
	[TaxRate] = @taxRate
WHERE [TaxProfileId] = @taxProfileId