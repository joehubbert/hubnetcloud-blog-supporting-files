CREATE PROCEDURE [dbo].[spGetAllSupplierOrderPaymentStatus]
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

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END