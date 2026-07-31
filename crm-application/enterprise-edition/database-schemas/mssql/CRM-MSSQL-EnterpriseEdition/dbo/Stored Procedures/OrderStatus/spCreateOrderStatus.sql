CREATE PROCEDURE [dbo].[spCreateOrderStatus]
	@activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@orderStatus NVARCHAR(50),
    @masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #OrderStatusTemp
			(
                [MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[OrderStatus] NVARCHAR(50) NOT NULL,
                [CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #OrderStatusTemp
			(
                [MasterDataTypeId],
				[OrderStatus],
                [CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
                @masterDataTypeId,
				@orderStatus,
                @companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[OrderStatus] E
				INNER JOIN #OrderStatusTemp ET ON E.[OrderStatus] = ET.[OrderStatus]
				WHERE E.[OrderStatus] = ET.[OrderStatus]
			)
			THROW 50000, 'Order Status already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[OrderStatus] AS target
			USING #OrderStatusTemp AS source
			ON target.[OrderStatus] = source.[OrderStatus]
			WHEN NOT MATCHED THEN
			INSERT
			(
                [MasterDataTypeId],
				[OrderStatus],
                [CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
                source.[MasterDataTypeId],
				source.[OrderStatus],
                source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #OrderStatusTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
