CREATE PROCEDURE [dbo].[spCreateCurrencyConversion]
    @companyConfigurationId UNIQUEIDENTIFIER,
    @currencyAId UNIQUEIDENTIFIER,
    @currencyBId UNIQUEIDENTIFIER,
    @conversionRate DECIMAL(18, 6),
    @effectiveDate DATE,
    @expiryDate DATE = NULL,
    @activeStatus BIT
AS
BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

            CREATE TABLE #CurrencyConversionTemp
            (
                [CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
                [CurrencyAId] UNIQUEIDENTIFIER NOT NULL,
                [CurrencyBId] UNIQUEIDENTIFIER NOT NULL,
                [ConversionRate] DECIMAL(18, 6) NOT NULL,
                [EffectiveDate] DATE NOT NULL,
                [ExpiryDate] DATE NULL,
                [ActiveStatus] BIT NOT NULL
            );

            INSERT INTO #CurrencyConversionTemp
            (
                [CompanyConfigurationId],
                [CurrencyAId],
                [CurrencyBId],
                [ConversionRate],
                [EffectiveDate],
                [ExpiryDate],
                [ActiveStatus]
            )
            VALUES
            (
                @companyConfigurationId,
                @currencyAId,
                @currencyBId,
                @conversionRate,
                @effectiveDate,
                @expiryDate,
                @activeStatus
            );

            -- Mark previous expired records as inactive
            UPDATE [dbo].[CurrencyConversion]
            SET [ActiveStatus] = 0
            WHERE [CompanyConfigurationId] = @companyConfigurationId
              AND [CurrencyAId] = @currencyAId
              AND [CurrencyBId] = @currencyBId
              AND [ActiveStatus] = 1
              AND (
                    ([ExpiryDate] IS NOT NULL AND [ExpiryDate] < @effectiveDate)
                    OR ([ExpiryDate] IS NULL AND [EffectiveDate] < @effectiveDate)
                  );

            -- Check for overlapping periods for the same currency pair and active status
            IF EXISTS (
                SELECT 1
                FROM [dbo].[CurrencyConversion] CC
                WHERE CC.[CompanyConfigurationId] = @companyConfigurationId
                  AND CC.[CurrencyAId] = @currencyAId
                  AND CC.[CurrencyBId] = @currencyBId
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
            ON target.[CompanyConfigurationId] = source.[CompanyConfigurationId]
            AND target.[CurrencyAId] = source.[CurrencyAId]
            AND target.[CurrencyBId] = source.[CurrencyBId]
            AND target.[EffectiveDate] = source.[EffectiveDate]
            AND (target.[ExpiryDate] = source.[ExpiryDate] OR (target.[ExpiryDate] IS NULL AND source.[ExpiryDate] IS NULL))
            AND target.[ActiveStatus] = source.[ActiveStatus]
            WHEN NOT MATCHED THEN
            INSERT
            (
                [CompanyConfigurationId],
                [CurrencyAId],
                [CurrencyBId],
                [ConversionRate],
                [EffectiveDate],
                [ExpiryDate],
                [ActiveStatus]
            )
            VALUES
            (
                source.[CompanyConfigurationId],
                source.[CurrencyAId],
                source.[CurrencyBId],
                source.[ConversionRate],
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