CREATE PROCEDURE [dbo].[spGetOrderInvoice]
	@orderInvoiceId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Order Invoice Id],
			[Order Invoice Friendly Id]
			[Order Id],
			[Order Invoice],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwOrderInvoice]
			WHERE [Order Invoice Id] = @orderInvoiceId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END