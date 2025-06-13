CREATE PROCEDURE [dbo].[spUpdateSupplierOrderPaymentStatus]
	@activeStatus BIT,
	@supplierOrderPaymentStatusId UNIQUEIDENTIFIER,
	@supplierOrderPaymentStatus NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[SupplierOrderPaymentStatus]
			SET
				[SupplierOrderPaymentStatus] = @supplierOrderPaymentStatus,
				[ActiveStatus] = @activeStatus
			WHERE [SupplierOrderPaymentStatusId] = @supplierOrderPaymentStatusId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END