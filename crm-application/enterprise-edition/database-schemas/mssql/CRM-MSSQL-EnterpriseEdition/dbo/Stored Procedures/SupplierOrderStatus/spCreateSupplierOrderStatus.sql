CREATE PROCEDURE [dbo].[spCreateSupplierOrderStatus]
	@activeStatus BIT,
	@supplierOrderStatus NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #SupplierOrderStatusTemp
			(
				[SupplierOrderStatus] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #SupplierOrderStatusTemp
			(
				[SupplierOrderStatus],
				[ActiveStatus]
			)
			VALUES
			(
				@supplierOrderStatus,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[SupplierOrderStatus] SOS
			INNER JOIN #SupplierOrderStatusTemp SOST ON SOS.[SupplierOrderStatus] = SOST.[SupplierOrderStatus]
			WHERE SOS.[SupplierOrderStatus] = SOST.[SupplierOrderStatus]
			)
			THROW 50000, 'Supplier Order Status already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[SupplierOrderStatus] AS target
			USING #SupplierOrderStatusTemp AS source
			ON target.[SupplierOrderStatus] = source.[SupplierOrderStatus]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[SupplierOrderStatus],
				[ActiveStatus]
			)
			VALUES
			(
				source.[SupplierOrderStatus],
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