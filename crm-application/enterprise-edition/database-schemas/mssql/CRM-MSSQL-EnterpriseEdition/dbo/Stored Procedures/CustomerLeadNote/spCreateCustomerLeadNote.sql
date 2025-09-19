CREATE PROCEDURE [dbo].[spCreateCustomerLeadNote]
	@customerLeadId UNIQUEIDENTIFIER,
	@customerLeadNote NVARCHAR(4000),
	@customerLeadNoteTitle NVARCHAR(50),
	@customerLeadNoteTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			INSERT INTO [dbo].[CustomerLeadNote]
			(
				[CustomerLeadId],
				[CustomerLeadNote],
				[CustomerLeadNoteTitle],
				[CustomerLeadNoteTypeId]
			)
			VALUES
			(
				@customerLeadId,
				@customerLeadNote,
				@customerLeadNoteTitle,
				@customerLeadNoteTypeId
			)

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END