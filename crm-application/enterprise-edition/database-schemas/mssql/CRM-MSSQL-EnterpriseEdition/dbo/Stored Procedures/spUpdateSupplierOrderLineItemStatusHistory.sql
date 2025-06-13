CREATE PROCEDURE [dbo].[spUpdateSupplierOrderLineItemStatusHistory]
	@supplierOrderLineItemStatusId UNIQUEIDENTIFIER,
	@supplierOrderLineItemStatusHistoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[SupplierOrderLineItemStatusHistory]
			SET 
				[SupplierOrderLineItemStatusId] = @supplierOrderLineItemStatusId
			WHERE [SupplierOrderLineItemStatusHistoryId] = @supplierOrderLineItemStatusHistoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END