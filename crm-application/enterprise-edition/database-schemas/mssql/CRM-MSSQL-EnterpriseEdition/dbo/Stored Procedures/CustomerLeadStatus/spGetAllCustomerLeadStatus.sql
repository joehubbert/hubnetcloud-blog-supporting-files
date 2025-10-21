CREATE PROCEDURE [dbo].[spGetAllCustomerLeadStatus]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Customer Lead Status Id],
			[Master Data Type Id],
			[Master Data Type],
			[Master Data Type Code],
			[Is Custom],
			[Customer Lead Status],
			[Customer Lead Status Code],
			[Company Configuration Id],
			[Company Name],
			[Active Status]
			FROM [dbo].[vwCustomerLeadStatus]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END