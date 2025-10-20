CREATE PROCEDURE [dbo].[spCreateProductSalesSubRegion]
	@activeStatus BIT,
	@effectiveDate DATE,
	@expiryDate DATE = NULL,
	@productId UNIQUEIDENTIFIER,
	@salesSubRegionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

            CREATE TABLE #ProductSalesSubRegionTemp
            (
	            [ActiveStatus] BIT NOT NULL,
	            [EffectiveDate] DATE NOT NULL,
	            [ExpiryDate] DATE NULL,
	            [ProductId] UNIQUEIDENTIFIER NOT NULL,
	            [SalesSubRegionId] UNIQUEIDENTIFIER NOT NULL
            )

            INSERT INTO #ProductSalesSubRegionTemp
            (
	            [ActiveStatus],
	            [EffectiveDate],
	            [ExpiryDate],
	            [ProductId],
	            [SalesSubRegionId]
            )
            VALUES
            (
	            @activeStatus,
	            @effectiveDate,
	            @expiryDate,
	            @productId,
	            @salesSubRegionId
            )

                -- Mark previous expired records as inactive
                UPDATE [dbo].[ProductSalesSubRegion]
                SET [ActiveStatus] = 0
                WHERE [ProductId] = @productId
                  AND [SalesSubRegionId] = @salesSubRegionId
                  AND [ActiveStatus] = 1
                  AND (
                        ([ExpiryDate] IS NOT NULL AND [ExpiryDate] < @effectiveDate)
                        OR ([ExpiryDate] IS NULL AND [EffectiveDate] < @effectiveDate)
                      );

                -- Check for overlapping periods for the same product/sales sub region pair and active status
                IF EXISTS 
                (
                    SELECT 1
                    FROM [dbo].[ProductSalesSubRegion] PSSR
                    WHERE PSSR.[ProductId] = @productId
                      AND PSSR.[SalesSubRegionId] = @salesSubRegionId
                      AND PSSR.[ActiveStatus] = @activeStatus
                      AND (
                            (PSSR.[ExpiryDate] IS NULL AND (@expiryDate IS NULL OR @effectiveDate <= PSSR.[EffectiveDate]))
                            OR
                            (PSSR.[ExpiryDate] IS NOT NULL AND @effectiveDate <= PSSR.[ExpiryDate] AND ( @expiryDate IS NULL OR @expiryDate >= PSSR.[EffectiveDate] ))
                          )
                )
                BEGIN
                    DROP TABLE #ProductSalesSubRegionTemp;
                    THROW 50000, 'Product Sales Sub Region allocation already exists for the specified period, please update the existing record.', 1;
                END

            MERGE INTO [dbo].[ProductSalesSubRegion] AS target
            USING #ProductSalesSubRegionTemp AS source
            ON target.[ProductId] = source.[ProductId]
            AND target.[SalesSubRegionId] = source.[SalesSubRegionId]
            WHEN NOT MATCHED THEN
            INSERT
            (
	            [ActiveStatus],
                [EffectiveDate],
                [ExpiryDate],
	            [ProductId],
	            [SalesSubRegionId]
            )
            VALUES
            (
	            source.[ActiveStatus],
                source.[EffectiveDate],
                source.[ExpiryDate],
	            source.[ProductId],
	            source.[SalesSubRegionId]
            );

            DROP TABLE #ProductSalesSubRegionTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END