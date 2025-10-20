CREATE PROCEDURE [dbo].[spGetSupplierOrderLineItemStatusHistory]
	@supplierOrderLineItemStatusHistoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Supplier Order Line Item Status History Id],
			[Supplier Order Line Item Id],
			[Supplier Order Line Item Status Id],
			[Supplier Order Line Item Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwSupplierOrderLineItemStatusHistory]
			WHERE [Supplier Order Line Item Status History Id] = @supplierOrderLineItemStatusHistoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END