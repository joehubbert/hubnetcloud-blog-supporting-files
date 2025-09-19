CREATE PROCEDURE [dbo].[spUpdateSupplierOrderLineItemStatus]
	@activeStatus BIT,
	@supplierOrderLineItemStatus NVARCHAR(50),
	@supplierOrderLineItemStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[SupplierOrderLineItemStatus]
			SET 
				[ActiveStatus] = @activeStatus,
				[SupplierOrderLineItemStatus] = @supplierOrderLineItemStatus
			WHERE [SupplierOrderLineItemStatusId] = @supplierOrderLineItemStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END