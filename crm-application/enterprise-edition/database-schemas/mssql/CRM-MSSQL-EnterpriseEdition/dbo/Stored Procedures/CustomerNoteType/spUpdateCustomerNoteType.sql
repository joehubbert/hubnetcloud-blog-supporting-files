CREATE PROCEDURE [dbo].[spUpdateCustomerNoteType]
	@activeStatus BIT,
	@customerNoteType NVARCHAR(50),
	@customerNoteTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CustomerNoteType]
			SET
				[ActiveStatus] = @activeStatus,
				[CustomerNoteType] = @customerNoteType
			WHERE [CustomerNoteTypeId] = @customerNoteTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END