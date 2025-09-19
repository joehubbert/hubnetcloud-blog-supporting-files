CREATE PROCEDURE [dbo].[spGetOrderPaymentStatus]
	@orderPaymentStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Order Payment Status Id],
			[Order Payment Status],
			[Active Status]
			FROM [dbo].[vwOrderPaymentStatus]
			WHERE [Order Payment Status Id] = @orderPaymentStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END