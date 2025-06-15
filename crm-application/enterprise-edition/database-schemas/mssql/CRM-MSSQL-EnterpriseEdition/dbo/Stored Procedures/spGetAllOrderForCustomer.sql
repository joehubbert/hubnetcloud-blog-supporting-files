CREATE PROCEDURE [dbo].[spGetAllOrderForCustomer]
	@customerId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Order Id],
			[Customer Id],
			[Customer Name],
			[Order Status],
			[Payment Method],
			[Total Order Value],
			[Currency Code],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwOrder]
			WHERE [Customer Id] = @customerId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END