CREATE PROCEDURE [dbo].[spDeleteSupplierOrderLineItemStatusHistory]
	@supplierOrderLineItemStatusHistoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		DELETE FROM [dbo].[SupplierOrderLineItemStatusHistory]
		WHERE [SupplierOrderLineItemStatusHistoryId] = @supplierOrderLineItemStatusHistoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END