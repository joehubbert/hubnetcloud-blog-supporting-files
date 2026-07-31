CREATE PROCEDURE [dbo].[spGetOrderStatus]
	@orderStatusId UNIQUEIDENTIFIER
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
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwOrderStatus]
			WHERE [Order Status Id] = @orderStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END
