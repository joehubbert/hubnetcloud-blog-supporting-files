CREATE PROCEDURE [dbo].[spGetAllOrderInvoice]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Order Invoice Id],
			[Order Id],
			[Order Invoice],
			[Order Invoice Date],
			[Order Invoice Friendly Id]
			FROM [dbo].[vwOrderInvoice]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END