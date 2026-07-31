CREATE PROCEDURE [dbo].[spCreateSupplierOrderLineItemStatus]
	@activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@supplierOrderLineItemStatus NVARCHAR(50),
    @masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #SupplierOrderLineItemStatusTemp
			(
                [MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[SupplierOrderLineItemStatus] NVARCHAR(50) NOT NULL,
                [CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #SupplierOrderLineItemStatusTemp
			(
                [MasterDataTypeId],
				[SupplierOrderLineItemStatus],
                [CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
                @masterDataTypeId,
				@supplierOrderLineItemStatus,
                @companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[SupplierOrderLineItemStatus] E
				INNER JOIN #SupplierOrderLineItemStatusTemp ET ON E.[SupplierOrderLineItemStatus] = ET.[SupplierOrderLineItemStatus]
				WHERE E.[SupplierOrderLineItemStatus] = ET.[SupplierOrderLineItemStatus]
			)
			THROW 50000, 'Supplier Order Line Item Status already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[SupplierOrderLineItemStatus] AS target
			USING #SupplierOrderLineItemStatusTemp AS source
			ON target.[SupplierOrderLineItemStatus] = source.[SupplierOrderLineItemStatus]
			WHEN NOT MATCHED THEN
			INSERT
			(
                [MasterDataTypeId],
				[SupplierOrderLineItemStatus],
                [CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
                source.[MasterDataTypeId],
				source.[SupplierOrderLineItemStatus],
                source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #SupplierOrderLineItemStatusTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
