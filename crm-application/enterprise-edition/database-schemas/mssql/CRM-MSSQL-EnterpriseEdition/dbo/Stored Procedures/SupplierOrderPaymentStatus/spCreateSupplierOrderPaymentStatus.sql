CREATE PROCEDURE [dbo].[spCreateSupplierOrderPaymentStatus]
	@activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@supplierOrderPaymentStatus NVARCHAR(50),
    @masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #SupplierOrderPaymentStatusTemp
			(
                [MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[SupplierOrderPaymentStatus] NVARCHAR(50) NOT NULL,
                [CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #SupplierOrderPaymentStatusTemp
			(
                [MasterDataTypeId],
				[SupplierOrderPaymentStatus],
                [CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
                @masterDataTypeId,
				@supplierOrderPaymentStatus,
                @companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[SupplierOrderPaymentStatus] E
				INNER JOIN #SupplierOrderPaymentStatusTemp ET ON E.[SupplierOrderPaymentStatus] = ET.[SupplierOrderPaymentStatus]
				WHERE E.[SupplierOrderPaymentStatus] = ET.[SupplierOrderPaymentStatus]
			)
			THROW 50000, 'Supplier Order Payment Status already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[SupplierOrderPaymentStatus] AS target
			USING #SupplierOrderPaymentStatusTemp AS source
			ON target.[SupplierOrderPaymentStatus] = source.[SupplierOrderPaymentStatus]
			WHEN NOT MATCHED THEN
			INSERT
			(
                [MasterDataTypeId],
				[SupplierOrderPaymentStatus],
                [CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
                source.[MasterDataTypeId],
				source.[SupplierOrderPaymentStatus],
                source.[CompanyConfigurationId],
				source.[ActiveStatus]
			);

			DROP TABLE #SupplierOrderPaymentStatusTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
