CREATE PROCEDURE [dbo].[spGetSupplierOrderPaymentStatus]
	@supplierOrderPaymentStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Supplier Order Payment Status Id],
			[Supplier Order Payment Status],
			[Active Status]
			FROM [dbo].[vwSupplierOrderPaymentStatus]
			WHERE [Supplier Order Payment Status Id] = @supplierOrderPaymentStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END