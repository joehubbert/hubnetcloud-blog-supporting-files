CREATE PROCEDURE [dbo].[spGetCustomerNote]
	@customerNoteId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Customer Note Id],
			[Customer Note Title],
			[Customer Note Type Id],
			[Customer Note Type],
			[Customer Note],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwCustomerNote]
			WHERE [Customer Note Id] = @customerNoteId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END