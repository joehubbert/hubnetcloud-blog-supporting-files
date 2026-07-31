CREATE PROCEDURE [dbo].[spGetCustomerNoteType]
	@customerNoteTypeId UNIQUEIDENTIFIER
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
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwCustomerNoteType]
			WHERE [Customer Note Type Id] = @customerNoteTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END