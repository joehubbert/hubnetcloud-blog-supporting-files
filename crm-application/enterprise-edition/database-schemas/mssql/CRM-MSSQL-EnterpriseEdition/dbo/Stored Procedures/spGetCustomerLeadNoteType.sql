CREATE PROCEDURE [dbo].[spGetCustomerLeadNoteType]
	@customerLeadNoteTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Customer Lead Note Type Id],
			[Customer Lead Note Type],
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwCustomerLeadNoteType]
			WHERE [Customer Lead Note Type Id] = @customerLeadNoteTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END