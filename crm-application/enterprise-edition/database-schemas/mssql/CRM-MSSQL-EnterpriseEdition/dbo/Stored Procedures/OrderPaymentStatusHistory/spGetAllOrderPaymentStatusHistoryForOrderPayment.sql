CREATE PROCEDURE [dbo].[spGetAllOrderPaymentStatusHistoryForOrderPayment]
	@orderPaymentId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Order Payment Status History Id],
			[Order Id],
			[Order Payment Id],
			[Order Payment Status Id],
			[Order Payment Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwOrderPaymentStatusHistory]
			WHERE [Order Payment Id] = @orderPaymentId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END