CREATE PROCEDURE [dbo].[spDeleteCurrencyConversion]
	@currencyConversionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		DELETE CC
		FROM [dbo].[CurrencyConversion] CC
		INNER JOIN [dbo].[MasterDataType] MDT ON CC.[MasterDataTypeId] = MDT.[MasterDataTypeId]
		WHERE CC.[CurrencyConversionId] = @currencyConversionId
		AND MDT.[IsCustom] = 1

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END