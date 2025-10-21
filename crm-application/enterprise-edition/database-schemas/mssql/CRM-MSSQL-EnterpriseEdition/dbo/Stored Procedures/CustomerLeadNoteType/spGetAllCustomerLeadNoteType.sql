CREATE PROCEDURE [dbo].[spGetAllCustomerLeadNoteType]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Customer Lead Note Type Id],
			[Master Data Type Id],
			[Master Data Type],
			[Master Data Type Code],
			[Is Custom],
			[Customer Lead Note Type],
			[Customer Lead Note Type Code],
			[Company Configuration Id],
			[Company Name],
			[Active Status]
			FROM [dbo].[vwCustomerLeadNoteType]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END