CREATE PROCEDURE [dbo].[spGetAllOrderQuote]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Order Id],
			[Customer Id],
			[Order Quote Id],
			[Order Quote],
			[Order Quote Date],
			[Order Quote Friendly Id]
			FROM [dbo].[vwOrderQuote]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END