CREATE PROCEDURE [dbo].[spCreateOrderPaymentStatus]
	@activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@orderPaymentStatus NVARCHAR(50),
    @masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #OrderPaymentStatusTemp
			(
                [MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[OrderPaymentStatus] NVARCHAR(50) NOT NULL,
                [CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #OrderPaymentStatusTemp
			(
                [MasterDataTypeId],
				[OrderPaymentStatus],
                [CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
                @masterDataTypeId,
				@orderPaymentStatus,
                @companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[OrderPaymentStatus] E
				INNER JOIN #OrderPaymentStatusTemp ET ON E.[OrderPaymentStatus] = ET.[OrderPaymentStatus]
				AND (E.[CompanyConfigurationId] = ET.[CompanyConfigurationId] OR (E.[CompanyConfigurationId] IS NULL AND ET.[CompanyConfigurationId] IS NULL))
				WHERE E.[OrderPaymentStatus] = ET.[OrderPaymentStatus]
			)
			THROW 50000, 'Order Payment Status already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[OrderPaymentStatus] AS target
			USING #OrderPaymentStatusTemp AS source
			ON target.[OrderPaymentStatus] = source.[OrderPaymentStatus]
			AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
			WHEN NOT MATCHED THEN
			INSERT
			(
                [MasterDataTypeId],
				[OrderPaymentStatus],
                [CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
                source.[MasterDataTypeId],
				source.[OrderPaymentStatus],
                source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #OrderPaymentStatusTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
