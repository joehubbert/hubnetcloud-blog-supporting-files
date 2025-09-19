CREATE PROCEDURE [dbo].[spGetAllOrderPayment]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Order Id],
			[Order Payment Id],
			[Payment Method Id],
			[Payment Method],
			[Payment Amount]
			FROM [dbo].[vwOrderPayment]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END