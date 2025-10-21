CREATE PROCEDURE [dbo].[spUpdateCurrencyConversion]
    @activeStatus BIT,
    @baseCurrencyConversionRate DECIMAL(18, 8),
    @baseCurrencyId UNIQUEIDENTIFIER,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@currencyConversionId UNIQUEIDENTIFIER,
    @effectiveDate DATE,
    @expiryDate DATE = NULL,
	@masterDataTypeId UNIQUEIDENTIFIER,
    @targetCurrencyConversionRate DECIMAL(18, 8),
    @targetCurrencyId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CurrencyConversion]
			SET
				[ActiveStatus] = @activeStatus,
				[BaseCurrencyConversionRate] = @baseCurrencyConversionRate,
				[BaseCurrencyId] = @baseCurrencyId,
				[CompanyConfigurationId] = @companyConfigurationId,
				[EffectiveDate] = @effectiveDate,
				[ExpiryDate] = @expiryDate,
				[MasterDataTypeId] = @masterDataTypeId,
				[TargetCurrencyConversionRate] = @targetCurrencyConversionRate,
				[TargetCurrencyId] = @targetCurrencyId
			WHERE [CurrencyConversionId] = @currencyConversionId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END