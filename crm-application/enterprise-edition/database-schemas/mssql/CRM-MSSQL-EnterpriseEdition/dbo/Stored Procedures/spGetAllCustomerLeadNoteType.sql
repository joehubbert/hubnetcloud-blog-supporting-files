CREATE PROCEDURE [dbo].[spGetAllCustomerLeadNoteType]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Customer Lead Note Type Id],
			[Customer Lead Note Type],
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