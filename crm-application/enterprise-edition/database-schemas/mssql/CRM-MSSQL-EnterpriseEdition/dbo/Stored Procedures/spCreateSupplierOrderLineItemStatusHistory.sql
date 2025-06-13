CREATE PROCEDURE [dbo].[spCreateSupplierOrderLineItemStatusHistory]
	@supplierOrderLineItemId UNIQUEIDENTIFIER,
	@supplierOrderLineItemStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			INSERT INTO [dbo].[SupplierOrderLineItemStatusHistory]
			(
				[SupplierOrderLineItemId],
				[SupplierOrderLineItemStatusId]
			)
			VALUES
			(
				@supplierOrderLineItemId,
				@supplierOrderLineItemStatusId
			)

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END