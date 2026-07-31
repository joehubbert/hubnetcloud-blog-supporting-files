CREATE PROCEDURE [dbo].[spGetAllOrderStatus]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Order Status Id],
            [Master Data Type Id],
            [Master Data Type],
            [Master Data Type Code],
            [Is Custom],
			[Order Status],
            [Company Configuration Id],
            [Company Name],
			[Active Status]
			FROM [dbo].[vwOrderStatus]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
