CREATE PROCEDURE [dbo].[spGetAllCustomerNoteType]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Customer Note Type Id],
			[Master Data Type Id],
			[Master Data Type],
			[Master Data Type Code],
			[Is Custom],
			[Customer Note Type],
			[Company Configuration Id],
			[Company Name],
			[Active Status]
			FROM [dbo].[vwCustomerNoteType]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END