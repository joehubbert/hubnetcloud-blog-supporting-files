CREATE PROCEDURE [dbo].[spGetAllCustomerLeadNote]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Customer Lead Note Id],
			[Customer Lead Note Title],
			[Customer Lead Note Type Id],
			[Customer Lead Note Type],
			[Customer Lead Note],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwCustomerLeadNote]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END