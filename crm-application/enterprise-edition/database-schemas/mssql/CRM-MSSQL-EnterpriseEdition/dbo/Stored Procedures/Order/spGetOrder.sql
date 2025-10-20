CREATE PROCEDURE [dbo].[spGetOrder]
	@orderId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Order Id],
			[Order Type Id],
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
			[Modified By],
			[Row Version]
			FROM [dbo].[vwOrder]
			WHERE [Order Id] = @orderId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END