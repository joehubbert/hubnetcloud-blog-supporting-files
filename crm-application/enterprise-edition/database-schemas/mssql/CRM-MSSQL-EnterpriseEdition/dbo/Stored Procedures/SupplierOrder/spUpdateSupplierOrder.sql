CREATE PROCEDURE [dbo].[spUpdateSupplierOrder]
	@internalReference NVARCHAR(50) = NULL,
	@supplierId UNIQUEIDENTIFIER,
	@supplierOrderId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[SupplierOrder]
			SET 
				[InternalReference] = @internalReference,
				[SupplierId] = @supplierId
			WHERE [SupplierOrderId] = @supplierOrderId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END