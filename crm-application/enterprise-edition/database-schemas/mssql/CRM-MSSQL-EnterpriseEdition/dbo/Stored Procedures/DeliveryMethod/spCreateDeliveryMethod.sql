CREATE PROCEDURE [dbo].[spCreateDeliveryMethod]
	@activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@deliveryCost MONEY,
	@deliveryMethod NVARCHAR(50),
	@deliveryTimeDays INT,
    @masterDataTypeId UNIQUEIDENTIFIER,
	@taxProfileId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #DeliveryMethodTemp
			(
                [MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
                [CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[TaxProfileId] UNIQUEIDENTIFIER NOT NULL,
				[DeliveryMethod] NVARCHAR(50) NOT NULL,
				[DeliveryCost] MONEY NOT NULL,
				[DeliveryTimeDays] INT NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #DeliveryMethodTemp
			(
                [MasterDataTypeId],
                [CompanyConfigurationId],
				[TaxProfileId],
				[DeliveryMethod],
				[DeliveryCost],
				[DeliveryTimeDays],
				[ActiveStatus]
			)
			VALUES
			(
                @masterDataTypeId,
                @companyConfigurationId,
				@taxProfileId,
				@deliveryMethod,
				@deliveryCost,
				@deliveryTimeDays,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[DeliveryMethod] DM
				INNER JOIN #DeliveryMethodTemp DMT ON DM.[TaxProfileId] = DMT.[TaxProfileId]
				AND DM.[DeliveryMethod] = DMT.[DeliveryMethod]
				AND DM.[DeliveryCost] = DMT.[DeliveryCost]
				AND DM.[DeliveryTimeDays] = DMT.[DeliveryTimeDays]
				WHERE DM.[TaxProfileId] = DMT.[TaxProfileId]
				AND DM.[DeliveryMethod] = DMT.[DeliveryMethod]
				AND DM.[DeliveryCost] = DMT.[DeliveryCost]
				AND DM.[DeliveryTimeDays] = DMT.[DeliveryTimeDays]
			)
			THROW 50000, 'Delivery Method already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[DeliveryMethod] AS target
			USING #DeliveryMethodTemp AS source
			ON target.[TaxProfileId] = source.[TaxProfileId]
			AND target.[DeliveryMethod] = source.[DeliveryMethod]
			AND target.[DeliveryCost] = source.[DeliveryCost]
			AND target.[DeliveryTimeDays] = source.[DeliveryTimeDays]
			WHEN NOT MATCHED THEN
			INSERT
			(
                [MasterDataTypeId],
                [CompanyConfigurationId],
				[TaxProfileId],
				[DeliveryMethod],
				[DeliveryCost],
				[DeliveryTimeDays],
				[ActiveStatus]
			)
			VALUES
			(
                source.[MasterDataTypeId],
                source.[CompanyConfigurationId],
				source.[TaxProfileId],
				source.[DeliveryMethod],
				source.[DeliveryCost],
				source.[DeliveryTimeDays],
				source.[ActiveStatus]
			);

			DROP TABLE #DeliveryMethodTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
