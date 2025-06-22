CREATE PROCEDURE [dbo].[spUpdateCurrencyConversion]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER,
	@conversionRate DECIMAL(18, 8),
	@currencyConversionId UNIQUEIDENTIFIER,
	@effectiveDate DATE,
	@expiryDate DATE = NULL
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CurrencyConversion]
			SET
				[ActiveStatus] = @activeStatus,
				[CompanyConfigurationId] = @companyConfigurationId,
				[ConversionRate] = @conversionRate,
				[EffectiveDate] = @effectiveDate,
				[ExpiryDate] = @expiryDate
			WHERE [CurrencyConversionId] = @currencyConversionId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END