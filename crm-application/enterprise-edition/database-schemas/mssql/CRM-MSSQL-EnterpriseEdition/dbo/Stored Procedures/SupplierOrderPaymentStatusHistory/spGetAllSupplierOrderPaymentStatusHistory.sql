CREATE PROCEDURE [dbo].[spGetAllSupplierOrderPaymentStatusHistory]
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

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END