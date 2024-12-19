CREATE PROCEDURE [dbo].[spUpdateCurrency]
	@activeStatus BIT,
	@currencyCode NCHAR(3),
	@currencyId UNIQUEIDENTIFIER,
	@currencyName NVARCHAR(50)
AS

UPDATE [dbo].[Currency]
SET
	[ActiveStatus] = @activeStatus,
	[CurrencyCode] = @currencyCode,
	[CurrencyName] = @currencyName
WHERE [CurrencyId] = @currencyId