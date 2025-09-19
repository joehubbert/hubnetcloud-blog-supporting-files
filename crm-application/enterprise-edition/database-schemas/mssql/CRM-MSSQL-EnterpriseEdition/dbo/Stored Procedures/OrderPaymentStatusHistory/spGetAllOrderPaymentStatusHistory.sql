CREATE PROCEDURE [dbo].[spGetAllOrderPaymentStatusHistory]
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

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END