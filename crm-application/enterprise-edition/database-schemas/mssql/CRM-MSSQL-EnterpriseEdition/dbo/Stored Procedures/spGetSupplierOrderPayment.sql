CREATE PROCEDURE [dbo].[spGetSupplierOrderPayment]
	@supplierOrderPaymentId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		SELECT
		[Supplier Order Payment Id],
		[Supplier Order Id],
		[Payment Method Id],
		[Payment Method],
		[Payment Amount]
		FROM [dbo].[vwSupplierOrderPayment]
		WHERE [Supplier Order Id] = @supplierOrderPaymentId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END