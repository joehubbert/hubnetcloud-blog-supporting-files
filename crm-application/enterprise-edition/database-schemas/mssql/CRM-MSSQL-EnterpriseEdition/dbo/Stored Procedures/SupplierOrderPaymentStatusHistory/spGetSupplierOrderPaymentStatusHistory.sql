CREATE PROCEDURE [dbo].[spGetSupplierOrderPaymentStatusHistory]
	@supplierOrderPaymentStatusHistoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Supplier Order Payment Status History Id],
			[Supplier Order Id],
			[Supplier Order Payment Id],
			[Supplier Order Payment Status Id],
			[Supplier Order Payment Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwSupplierOrderPaymentStatusHistory]
			WHERE [Supplier Order Payment Status History Id] = @supplierOrderPaymentStatusHistoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END