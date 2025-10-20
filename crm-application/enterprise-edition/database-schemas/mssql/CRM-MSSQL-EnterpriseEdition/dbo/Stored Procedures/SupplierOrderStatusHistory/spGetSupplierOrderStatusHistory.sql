CREATE PROCEDURE [dbo].[spGetSupplierOrderStatusHistory]
	@supplierOrderStatusHistoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Supplier Order Status History Id],
			[Supplier Order Id],
			[Supplier Order Status Id],
			[Supplier Order Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwSupplierOrderStatusHistory]
			WHERE [Supplier Order Status History Id] = @supplierOrderStatusHistoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END