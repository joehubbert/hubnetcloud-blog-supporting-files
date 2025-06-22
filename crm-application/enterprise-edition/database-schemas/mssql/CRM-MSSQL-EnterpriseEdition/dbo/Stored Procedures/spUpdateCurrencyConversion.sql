CREATE PROCEDURE [dbo].[spUpdateCurrencyConversion]
    @activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER,
	@currencyConversionId UNIQUEIDENTIFIER,
    @effectiveDate DATE,
    @expiryDate DATE = NULL,
    @targetCurrencyConversionRate DECIMAL(18, 8)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CurrencyConversion]
			SET
				[ActiveStatus] = @activeStatus,
				[CompanyConfigurationId] = @companyConfigurationId,
				[EffectiveDate] = @effectiveDate,
				[ExpiryDate] = @expiryDate,
				[TargetCurrencyConversionRate] = @targetCurrencyConversionRate
			WHERE [CurrencyConversionId] = @currencyConversionId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END