CREATE PROCEDURE [dbo].[spCreateSupplierOrderPaymentStatus]
	@activeStatus BIT,
	@supplierOrderPaymentStatus NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #SupplierOrderPaymentStatusTemp
			(
				[SupplierOrderPaymentStatus] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #SupplierOrderPaymentStatusTemp
			(
				[SupplierOrderPaymentStatus],
				[ActiveStatus]
			)
			VALUES
			(
				@supplierOrderPaymentStatus,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[SupplierOrderPaymentStatus] SOPS
				INNER JOIN #SupplierOrderPaymentStatusTemp SOPST ON SOPS.[SupplierOrderPaymentStatus] = SOPST.[SupplierOrderPaymentStatus]
				WHERE SOPS.[SupplierOrderPaymentStatus] = SOPST.[SupplierOrderPaymentStatus]
			)
			THROW 50000, 'Supplier Order Payment Status already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[SupplierOrderPaymentStatus] AS target
			USING #SupplierOrderPaymentStatusTemp AS source
			ON target.[SupplierOrderPaymentStatus] = source.[SupplierOrderPaymentStatus]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[SupplierOrderPaymentStatus],
				[ActiveStatus]
			)
			VALUES
			(
				source.[SupplierOrderPaymentStatus],
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