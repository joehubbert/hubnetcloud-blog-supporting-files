CREATE PROCEDURE [dbo].[spCreateCurrencyConversion]
    @activeStatus BIT,
    @baseCurrencyConversionRate DECIMAL(18, 8),
    @baseCurrencyId UNIQUEIDENTIFIER,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
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

            CREATE TABLE #CurrencyConversionTemp
            (
                [MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
                [CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
                [BaseCurrencyId] UNIQUEIDENTIFIER NOT NULL,
                [TargetCurrencyId] UNIQUEIDENTIFIER NOT NULL,
                [BaseCurrencyConversionRate] DECIMAL(18, 6) NOT NULL,
                [TargetCurrencyConversionRate] DECIMAL(18, 6) NOT NULL,
                [EffectiveDate] DATE NOT NULL,
                [ExpiryDate] DATE NULL,
                [ActiveStatus] BIT NOT NULL
            );

            INSERT INTO #CurrencyConversionTemp
            (
                [MasterDataTypeId],
                [CompanyConfigurationId],
                [BaseCurrencyId],
                [TargetCurrencyId],
                [BaseCurrencyConversionRate],
                [TargetCurrencyConversionRate],
                [EffectiveDate],
                [ExpiryDate],
                [ActiveStatus]
            )
            VALUES
            (
                @masterDataTypeId,
                @companyConfigurationId,
                @baseCurrencyId,
                @targetCurrencyId,
                @baseCurrencyConversionRate,
                @targetCurrencyConversionRate,
                @effectiveDate,
                @expiryDate,
                @activeStatus
            );

            -- Mark previous expired records as inactive
            UPDATE [dbo].[CurrencyConversion]
            SET [ActiveStatus] = 0
            WHERE [CompanyConfigurationId] = @companyConfigurationId
              AND [BaseCurrencyId] = @baseCurrencyId
              AND [TargetCurrencyId] = @targetCurrencyId
              AND [ActiveStatus] = 1
              AND (
                    ([ExpiryDate] IS NOT NULL AND [ExpiryDate] < @effectiveDate)
                    OR ([ExpiryDate] IS NULL AND [EffectiveDate] < @effectiveDate)
                  );

            -- Check for overlapping periods for the same currency pair and active status
            IF EXISTS 
            (
                SELECT 1
                FROM [dbo].[CurrencyConversion] CC
                WHERE (CC.[CompanyConfigurationId] = @companyConfigurationId OR (CC.[CompanyConfigurationId] IS NULL AND @companyConfigurationId IS NULL))
                  AND CC.[MasterDataTypeId] = @masterDataTypeId
                  AND CC.[BaseCurrencyId] = @baseCurrencyId
                  AND CC.[TargetCurrencyId] = @targetCurrencyId
                  AND CC.[ActiveStatus] = @activeStatus
                  AND (
                        (CC.[ExpiryDate] IS NULL AND (@expiryDate IS NULL OR @effectiveDate <= CC.[EffectiveDate]))
                        OR
                        (CC.[ExpiryDate] IS NOT NULL AND @effectiveDate <= CC.[ExpiryDate] AND ( @expiryDate IS NULL OR @expiryDate >= CC.[EffectiveDate] ))
                      )
            )
            BEGIN
                DROP TABLE #CurrencyConversionTemp;
                THROW 50000, 'Currency Conversion Rate already exists for the specified period/company configuration, please update the existing record.', 1;
            END

            MERGE INTO [dbo].[CurrencyConversion] AS target
            USING #CurrencyConversionTemp AS source
            ON target.[MasterDataTypeId] = source.[MasterDataTypeId]
            AND target.[CompanyConfigurationId] = source.[CompanyConfigurationId]
            AND target.[BaseCurrencyId] = source.[BaseCurrencyId]
            AND target.[TargetCurrencyId] = source.[TargetCurrencyId]
            AND target.[EffectiveDate] = source.[EffectiveDate]
            AND (target.[ExpiryDate] = source.[ExpiryDate] OR (target.[ExpiryDate] IS NULL AND source.[ExpiryDate] IS NULL))
            AND target.[ActiveStatus] = source.[ActiveStatus]
            WHEN NOT MATCHED THEN
            INSERT
            (
                [MasterDataTypeId],
                [CompanyConfigurationId],
                [BaseCurrencyId],
                [TargetCurrencyId],
                [BaseCurrencyConversionRate],
                [TargetCurrencyConversionRate],
                [EffectiveDate],
                [ExpiryDate],
                [ActiveStatus]
            )
            VALUES
            (
                source.[MasterDataTypeId],
                source.[CompanyConfigurationId],
                source.[BaseCurrencyId],
                source.[TargetCurrencyId],
                source.[BaseCurrencyConversionRate],
                source.[TargetCurrencyConversionRate],
                source.[EffectiveDate],
                source.[ExpiryDate],
                source.[ActiveStatus]
            );

            DROP TABLE #CurrencyConversionTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END