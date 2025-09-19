CREATE PROCEDURE [dbo].[spUpdateCurrency]
	@activeStatus BIT,
	@currencyCode NCHAR(3),
	@currencyId UNIQUEIDENTIFIER,
	@currencyName NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[Currency]
			SET
				[ActiveStatus] = @activeStatus,
				[CurrencyCode] = @currencyCode,
				[CurrencyName] = @currencyName
			WHERE [CurrencyId] = @currencyId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END