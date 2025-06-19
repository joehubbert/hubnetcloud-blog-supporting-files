CREATE PROCEDURE [dbo].[spUpdateCustomerLeadNoteType]
	@activeStatus BIT,
	@customerLeadNoteType NVARCHAR(50),
	@customerLeadNoteTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CustomerLeadNoteType]
			SET
				[ActiveStatus] = @activeStatus,
				[CustomerLeadNoteType] = @customerLeadNoteType
			WHERE [CustomerLeadNoteTypeId] = @customerLeadNoteTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END