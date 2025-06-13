CREATE PROCEDURE [dbo].[spUpdateSupplierOrderStatus]
	@activeStatus BIT,
	@supplierOrderStatus NVARCHAR(50),
	@supplierOrderStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[SupplierOrderStatus]
			SET 
				[ActiveStatus] = @activeStatus,
				[SupplierOrderStatus] = @supplierOrderStatus
			WHERE [SupplierOrderStatusId] = @supplierOrderStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END