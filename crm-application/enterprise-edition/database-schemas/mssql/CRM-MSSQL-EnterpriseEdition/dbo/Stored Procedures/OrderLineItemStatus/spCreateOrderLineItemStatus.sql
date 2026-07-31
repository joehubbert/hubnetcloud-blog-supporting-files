CREATE PROCEDURE [dbo].[spCreateOrderLineItemStatus]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@orderLineItemStatus NVARCHAR(50),
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #OrderLineItemStatusTemp
			(
				[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[OrderLineItemStatus] NVARCHAR(50) NOT NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #OrderLineItemStatusTemp
			(
				[MasterDataTypeId],
				[OrderLineItemStatus],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataTypeId,
				@orderLineItemStatus,
				@companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[OrderLineItemStatus] OLIS
				INNER JOIN #OrderLineItemStatusTemp OLIST ON OLIS.[OrderLineItemStatus] = OLIST.[OrderLineItemStatus]
				WHERE OLIS.[OrderLineItemStatus] = OLIST.[OrderLineItemStatus]
			)
			THROW 50000, 'Order Line Item Status already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[OrderLineItemStatus] AS target
			USING #OrderLineItemStatusTemp AS source
			ON target.[OrderLineItemStatus] = source.[OrderLineItemStatus]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataTypeId],
				[OrderLineItemStatus],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataTypeId],
				source.[OrderLineItemStatus],
				source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #OrderLineItemStatusTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END