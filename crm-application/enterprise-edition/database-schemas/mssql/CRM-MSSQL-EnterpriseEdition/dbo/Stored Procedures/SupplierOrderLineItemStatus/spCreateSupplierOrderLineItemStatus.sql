CREATE PROCEDURE [dbo].[spCreateSupplierOrderLineItemStatus]
	@activeStatus BIT,
	@supplierOrderLineItemStatus NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #SupplierOrderLineItemStatusTemp
			(
				[SupplierOrderLineItemStatus] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #SupplierOrderLineItemStatusTemp
			(
				[SupplierOrderLineItemStatus],
				[ActiveStatus]
			)
			VALUES
			(
				@supplierOrderLineItemStatus,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[SupplierOrderLineItemStatus] SOLIS
				INNER JOIN #SupplierOrderLineItemStatusTemp SOLIST ON SOLIS.[SupplierOrderLineItemStatus] = SOLIST.[SupplierOrderLineItemStatus]
				WHERE SOLIS.[SupplierOrderLineItemStatus] = SOLIST.[SupplierOrderLineItemStatus]
			)
			THROW 50000, 'Supplier Order Line Item Status already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[SupplierOrderLineItemStatus] AS target
			USING #SupplierOrderLineItemStatusTemp AS source
			ON target.[SupplierOrderLineItemStatus] = source.[SupplierOrderLineItemStatus]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[SupplierOrderLineItemStatus],
				[ActiveStatus]
			)
			VALUES
			(
				source.[SupplierOrderLineItemStatus],
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