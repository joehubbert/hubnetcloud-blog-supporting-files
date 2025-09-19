CREATE PROCEDURE [dbo].[spGetAllNoteForCustomerLead]
	@customerLeadId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Customer Id],
			[Customer Lead Id],
			[Customer Lead Note Id],
			[Customer Lead Note Title],
			[Customer Lead Note Type],
			[Customer Lead Note],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwCustomerLeadNoteSummary]
			WHERE [Customer Lead Id] = @customerLeadId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END