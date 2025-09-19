CREATE PROCEDURE [dbo].[spGetAllOrderOutstandingForCustomer]
	@customerId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;
			SELECT
			[Order Id],
			[Customer Id],
			[Order Date],
			[Total Order Value]
			FROM [dbo].[vwOrderOutstanding]
			WHERE [Customer Id] = @customerId
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
		THROW;
	END CATCH
END