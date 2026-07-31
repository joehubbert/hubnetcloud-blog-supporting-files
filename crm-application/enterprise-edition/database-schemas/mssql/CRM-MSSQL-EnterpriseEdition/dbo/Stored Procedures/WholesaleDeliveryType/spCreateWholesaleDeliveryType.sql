CREATE PROCEDURE [dbo].[spCreateWholesaleDeliveryType]
	@activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@wholesaleDeliveryType NVARCHAR(50),
    @masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #WholesaleDeliveryTypeTemp
			(
                [MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[WholesaleDeliveryType] NVARCHAR(50) NOT NULL,
                [CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #WholesaleDeliveryTypeTemp
			(
                [MasterDataTypeId],
				[WholesaleDeliveryType],
                [CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
                @masterDataTypeId,
				@wholesaleDeliveryType,
                @companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[WholesaleDeliveryType] E
				INNER JOIN #WholesaleDeliveryTypeTemp ET ON E.[WholesaleDeliveryType] = ET.[WholesaleDeliveryType]
				WHERE E.[WholesaleDeliveryType] = ET.[WholesaleDeliveryType]
			)
			THROW 50000, 'Wholesale Delivery Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[WholesaleDeliveryType] AS target
			USING #WholesaleDeliveryTypeTemp AS source
			ON target.[WholesaleDeliveryType] = source.[WholesaleDeliveryType]
			WHEN NOT MATCHED THEN
			INSERT
			(
                [MasterDataTypeId],
				[WholesaleDeliveryType],
                [CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
                source.[MasterDataTypeId],
				source.[WholesaleDeliveryType],
                source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #WholesaleDeliveryTypeTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
