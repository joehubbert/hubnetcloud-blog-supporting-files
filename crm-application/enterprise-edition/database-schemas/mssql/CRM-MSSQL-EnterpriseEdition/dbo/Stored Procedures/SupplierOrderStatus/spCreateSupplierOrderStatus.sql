CREATE PROCEDURE [dbo].[spCreateSupplierOrderStatus]
	@activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@supplierOrderStatus NVARCHAR(50),
    @masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #SupplierOrderStatusTemp
			(
                [MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[SupplierOrderStatus] NVARCHAR(50) NOT NULL,
                [CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #SupplierOrderStatusTemp
			(
                [MasterDataTypeId],
				[SupplierOrderStatus],
                [CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
                @masterDataTypeId,
				@supplierOrderStatus,
                @companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[SupplierOrderStatus] E
				INNER JOIN #SupplierOrderStatusTemp ET ON E.[SupplierOrderStatus] = ET.[SupplierOrderStatus]
				AND (E.[CompanyConfigurationId] = ET.[CompanyConfigurationId] OR (E.[CompanyConfigurationId] IS NULL AND ET.[CompanyConfigurationId] IS NULL))
				WHERE E.[SupplierOrderStatus] = ET.[SupplierOrderStatus]
			)
			THROW 50000, 'Supplier Order Status already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[SupplierOrderStatus] AS target
			USING #SupplierOrderStatusTemp AS source
			ON target.[SupplierOrderStatus] = source.[SupplierOrderStatus]
			AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
			WHEN NOT MATCHED THEN
			INSERT
			(
                [MasterDataTypeId],
				[SupplierOrderStatus],
                [CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
                source.[MasterDataTypeId],
				source.[SupplierOrderStatus],
                source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #SupplierOrderStatusTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
